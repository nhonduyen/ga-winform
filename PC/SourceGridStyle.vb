Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class GridDataTable
    Inherits SourceGrid2.GridVirtual
    'Public Sub New()
    '    Selection.AutoClear = False
    '    AddHandler Selection.ClearCells, AddressOf Selection_ClearCells
    '    ContextMenuStyle = SourceGrid2.ContextMenuStyle.CopyPasteSelection
    '    m_MenuDelete = New MenuItem("Delete", New EventHandler(MenuDelete_Click))
    '    Selection.ContextMenuItems = New SourceGrid2.MenuCollection()
    '    Selection.ContextMenuItems.Add(m_MenuDelete)
    'End Sub

    Private m_MenuDelete As System.Windows.Forms.MenuItem
    Private m_DataTable As System.Data.DataTable

    Private m_DataCell As CellColumnTemplate()
    Private m_HeaderCell As CellHeaderDataTable
    Private m_ColHeaderCell As CellColHeaderDataTable
    Private m_RowHeaderCell As CellRowHeaderDataTable

    Private m_Style As GridDataTableStyle = GridDataTableStyle.[Default]
    Private m_EnableEdit As Boolean = True
    Private m_EnableDelete As Boolean = True

    Private m_DataSelection As ArrayList = Nothing
    'array of System.Data.DataRow 
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        UnLoadDataSource()

        MyBase.Dispose(disposing)
    End Sub


    Public Overridable Sub UnLoadDataSource()
        If m_DataTable IsNot Nothing Then
            RemoveHandler m_DataTable.RowChanged, AddressOf m_DataTable_RowChanged
            RemoveHandler m_DataTable.RowDeleted, AddressOf m_DataTable_RowDeleted

            m_DataTable = Nothing
        End If
        m_Sort = Nothing
    End Sub

    Public Overridable Sub LoadDataSource(ByVal p_Table As System.Data.DataTable)
        LoadDataSource(p_Table, GridDataTableStyle.[Default], GetColumnsFromDataTable(p_Table, m_EnableEdit))
    End Sub

    Public Overridable Sub LoadDataSource(ByVal p_Table As System.Data.DataTable, ByVal p_Style As GridDataTableStyle, ByVal p_DataColumns As CellColumnTemplate())
        'unload data source 
        UnLoadDataSource()

        m_DataTable = p_Table
        AddHandler m_DataTable.RowChanged, AddressOf m_DataTable_RowChanged
        AddHandler m_DataTable.RowDeleted, AddressOf m_DataTable_RowDeleted

        m_Style = p_Style

        If (p_Style And GridDataTableStyle.ColumnHeader) = GridDataTableStyle.ColumnHeader Then
            FixedRows = 1
        Else
            FixedRows = 0
        End If
        If (p_Style And GridDataTableStyle.RowHeader) = GridDataTableStyle.RowHeader Then
            FixedColumns = 1
        Else
            FixedColumns = 0
        End If
        [Redim](m_DataTable.Rows.Count + FixedRows, p_DataColumns.Length + FixedColumns)
        Selection.SelectionMode = SourceGrid2.GridSelectionMode.Row


        'Col Header Cell Template 
        m_ColHeaderCell = New CellColHeaderDataTable(m_DataTable)
        m_ColHeaderCell.BindToGrid(Me)

        'Row Header Cell Template 
        m_RowHeaderCell = New CellRowHeaderDataTable()
        m_RowHeaderCell.BindToGrid(Me)

        'Header Cell Template (0,0 cell) 
        m_HeaderCell = New CellHeaderDataTable()
        m_HeaderCell.BindToGrid(Me)

        'Data Cell Template (one for each column 
        m_DataCell = p_DataColumns
        For i As Integer = 0 To m_DataCell.Length - 1
            m_DataCell(i).BindToGrid(Me)
        Next

        RefreshDataSelection()
    End Sub

    Private m_Sort As String
    Protected Overridable Sub RefreshDataSelection()
        m_DataSelection = New ArrayList(m_DataTable.[Select](Nothing, m_Sort))
        RowsCount = m_DataSelection.Count + FixedRows
    End Sub

    Public Shared Function GetColumnsFromDataTable(ByVal p_Table As System.Data.DataTable, ByVal p_EnableEdit As Boolean) As CellColumnTemplate()
        Dim l_Cells As CellColumnTemplate()
        'Data Cell Template (one for each column 
        l_Cells = New CellColumnTemplate(p_Table.Columns.Count - 1) {}
        For c As Integer = 0 To p_Table.Columns.Count - 1
            l_Cells(c) = New CellColumnTemplate(p_Table.Columns(c), p_Table.Columns(c).Caption)
            l_Cells(c).DataModel.EnableEdit = p_EnableEdit
        Next
        Return l_Cells
    End Function

    Public Overloads Overrides Function GetCell(ByVal p_iRow As Integer, ByVal p_iCol As Integer) As SourceGrid2.Cells.ICellVirtual
        Try
            If m_DataTable IsNot Nothing Then
                If p_iRow < FixedRows AndAlso p_iCol < FixedColumns Then
                    Return m_HeaderCell
                ElseIf p_iRow < FixedRows Then
                    Return m_ColHeaderCell
                ElseIf p_iCol < FixedColumns Then
                    Return m_RowHeaderCell
                Else
                    Return m_DataCell(p_iCol - FixedColumns)
                End If
            Else
                Return Nothing
            End If
        Catch err As Exception
            System.Diagnostics.Debug.Assert(False, err.Message)
            Return Nothing
        End Try
    End Function

    Public ReadOnly Property DataTable() As System.Data.DataTable
        Get
            Return m_DataTable
        End Get
    End Property

    Public ReadOnly Property GridStyle() As GridDataTableStyle
        Get
            Return m_Style
        End Get
    End Property

    Public Property EnableEdit() As Boolean
        Get
            Return m_EnableEdit
        End Get
        Set(ByVal value As Boolean)
            m_EnableEdit = value
            RefreshCellsStyle()
        End Set
    End Property
    Public Property EnableDelete() As Boolean
        Get
            Return m_EnableDelete
        End Get
        Set(ByVal value As Boolean)
            m_EnableDelete = value
            RefreshCellsStyle()
        End Set
    End Property

    Private Sub RefreshCellsStyle()
        If m_DataCell IsNot Nothing Then
            For i As Integer = 0 To m_DataCell.Length - 1
                m_DataCell(i).DataModel.EnableEdit = m_EnableEdit
            Next
        End If
        If m_EnableDelete Then
            m_MenuDelete.Enabled = True
        Else
            m_MenuDelete.Enabled = False
        End If
    End Sub

    Public Overloads Overrides Sub SetCell(ByVal p_iRow As Integer, ByVal p_iCol As Integer, ByVal p_Cell As SourceGrid2.Cells.ICellVirtual)
        Throw New ApplicationException("Cannot set cell for this kind of grid")
    End Sub


    Protected Overloads Overrides Sub OnSortingRangeRows(ByVal e As SourceGrid2.SortRangeRowsEventArgs)
        MyBase.OnSortingRangeRows(e)

        Dim l_SortMode As String
        If e.Ascending Then
            l_SortMode = " ASC"
        Else
            l_SortMode = " DESC"
        End If

        m_Sort = m_DataCell(e.AbsoluteColKeys - FixedColumns).DataColumn.ColumnName + l_SortMode

        RefreshDataSelection()
    End Sub

    Public ReadOnly Property FocusDataRow() As System.Data.DataRow
        Get
            If Selection.FocusPosition.IsEmpty() OrElse Selection.FocusPosition.Row < FixedRows OrElse (Selection.FocusPosition.Row - 1) >= m_DataSelection.Count Then
                Return Nothing
            Else
                Return DirectCast(m_DataSelection(Selection.FocusPosition.Row - 1), System.Data.DataRow)
            End If
        End Get
    End Property
    Public ReadOnly Property FocusDataColumn() As System.Data.DataColumn
        Get
            If Selection.FocusPosition.IsEmpty() OrElse Selection.FocusPosition.Column < FixedColumns OrElse (Selection.FocusPosition.Column - 1) >= m_DataCell.Length Then
                Return Nothing
            Else
                Return m_DataCell(Selection.FocusPosition.Column - 1).DataColumn
            End If
        End Get
    End Property

    Private Sub Selection_ClearCells(ByVal sender As Object, ByVal e As EventArgs)
        If (m_Style And GridDataTableStyle.KeyCancDeleteRow) = GridDataTableStyle.KeyCancDeleteRow AndAlso m_EnableDelete Then
            DeleteFocusDataRow()
        End If
    End Sub
    'Private Sub MenuDelete_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    If m_EnableDelete Then
    '        DeleteFocusDataRow()
    '    End If
    'End Sub
    Public Sub DeleteFocusDataRow()
        Try
            If FocusDataRow IsNot Nothing Then
                If MessageBox.Show(Me, "Are you sure to delete selected row?", "Delete Row", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    FocusDataRow.Delete()
                    RefreshDataSelection()
                End If
            End If
        Catch err As Exception
            SourceLibrary.Windows.Forms.ErrorDialog.Show(Me, err, "Error")
        End Try
    End Sub


    Public Sub AddDataRow()
        Dim l_NewRow As System.Data.DataRow = m_DataTable.NewRow()
        m_DataTable.Rows.Add(l_NewRow)
        m_DataSelection.Add(l_NewRow)
        Rows.Insert(Rows.Count)
        Rows(Rows.Count - 1).Focus()
    End Sub

    Private Sub m_DataTable_RowChanged(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
        'InvalidateCells(); 
    End Sub
    Private Sub m_DataTable_RowDeleted(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
        InvalidateCells()
    End Sub

#Region "Cell class"
    Public Class CellColumnTemplate
        Inherits SourceGrid2.Cells.Virtual.CellVirtual
        Private m_DataColumn As System.Data.DataColumn
        Private m_ColumnCaption As String

        Public Sub New(ByVal p_DataColumn As System.Data.DataColumn, ByVal p_ColumnCaption As String)
            m_ColumnCaption = p_ColumnCaption
            m_DataColumn = p_DataColumn

            DataModel = SourceGrid2.Utility.CreateDataModel(m_DataColumn.DataType)
            DataModel.AllowNull = m_DataColumn.AllowDBNull
            DataModel.NullDisplayString = "<NULL>"
            DataModel.EnableEdit = Not m_DataColumn.[ReadOnly]
        End Sub

        Public Property ColumnCaption() As String
            Get
                Return m_ColumnCaption
            End Get
            Set(ByVal value As String)
                m_ColumnCaption = value
            End Set
        End Property

        Public ReadOnly Property DataColumn() As System.Data.DataColumn
            Get
                Return m_DataColumn
            End Get
        End Property

        Public Overloads Overrides Function GetValue(ByVal p_Position As SourceGrid2.Position) As Object
            Dim l_GridDataTable As GridDataTable = DirectCast(Grid, GridDataTable)
            Dim l_Row As System.Data.DataRow = DirectCast((l_GridDataTable.m_DataSelection(p_Position.Row - Grid.FixedRows)), System.Data.DataRow)
            Dim tmp As Object = l_Row(m_DataColumn)
            'If System.DBNull.Value = tmp Then
            '    Return Nothing
            'Else
            '    Return tmp
            'End If
            Return 0
        End Function

        Public Overloads Overrides Sub SetValue(ByVal p_Position As SourceGrid2.Position, ByVal p_Value As Object)
            Dim l_GridDataTable As GridDataTable = DirectCast(Grid, GridDataTable)
            Dim l_Row As System.Data.DataRow = DirectCast((l_GridDataTable.m_DataSelection(p_Position.Row - Grid.FixedRows)), System.Data.DataRow)
            If p_Value Is Nothing Then
                l_Row(m_DataColumn) = System.DBNull.Value
            Else
                l_Row(m_DataColumn) = p_Value
            End If

            OnValueChanged(New SourceGrid2.PositionEventArgs(p_Position, Me))
        End Sub
    End Class

    Private Class CellHeaderDataTable
        Inherits SourceGrid2.Cells.Virtual.Header
        Public Sub New()
        End Sub

        Public Overloads Overrides Function GetValue(ByVal p_Position As SourceGrid2.Position) As Object
            Return Nothing
        End Function

        Public Overloads Overrides Sub SetValue(ByVal p_Position As SourceGrid2.Position, ByVal p_Value As Object)
            Throw New ApplicationException("This cell cannot be modified")
        End Sub
    End Class

    Private Class CellRowHeaderDataTable
        Inherits SourceGrid2.Cells.Virtual.RowHeader
        Public Sub New()
        End Sub

        Public Overloads Overrides Function GetValue(ByVal p_Position As SourceGrid2.Position) As Object
            Return p_Position.Row
        End Function

        Public Overloads Overrides Sub SetValue(ByVal p_Position As SourceGrid2.Position, ByVal p_Value As Object)
            Throw New ApplicationException("This cell cannot be modified")
        End Sub
    End Class

    Private Class CellColHeaderDataTable
        Inherits SourceGrid2.Cells.Virtual.ColumnHeader
        Private m_DataTable As System.Data.DataTable
        Public Sub New(ByVal p_DataTable As System.Data.DataTable)
            m_DataTable = p_DataTable
        End Sub

        Public Overloads Overrides Function GetValue(ByVal p_Position As SourceGrid2.Position) As Object
            Return GetColCaption(p_Position.Column)
        End Function

        Public Overloads Overrides Sub SetValue(ByVal p_Position As SourceGrid2.Position, ByVal p_Value As Object)
            Throw New ApplicationException("This cell cannot be modified")
        End Sub

        Private m_ColumnSort As String = Nothing
        Private m_bAscending As Boolean = False

        Private Function GetColCaption(ByVal p_Column As Integer) As String
            Return DirectCast(Grid, GridDataTable).m_DataCell(p_Column - Grid.FixedColumns).ColumnCaption
        End Function

        Public Overloads Overrides Function GetSortStatus(ByVal p_Position As SourceGrid2.Position) As SourceGrid2.SortStatus
            If GetColCaption(p_Position.Column) = m_ColumnSort Then
                If m_bAscending Then
                    Return New SourceGrid2.SortStatus(SourceGrid2.GridSortMode.Ascending, True)
                Else
                    Return New SourceGrid2.SortStatus(SourceGrid2.GridSortMode.Descending, True)
                End If
            Else
                Return New SourceGrid2.SortStatus(SourceGrid2.GridSortMode.None, True)
            End If
        End Function

        Public Overloads Overrides Sub SetSortMode(ByVal p_Position As SourceGrid2.Position, ByVal p_Mode As SourceGrid2.GridSortMode)
            If p_Mode = SourceGrid2.GridSortMode.Ascending Then
                m_ColumnSort = GetColCaption(p_Position.Column)
                m_bAscending = True
            ElseIf p_Mode = SourceGrid2.GridSortMode.Descending Then
                m_ColumnSort = GetColCaption(p_Position.Column)
                m_bAscending = False
            Else
                m_ColumnSort = Nothing
            End If
        End Sub
    End Class
#End Region

    Public Enum GridDataTableStyle
        None = 0
        KeyCancDeleteRow = 4
        RowHeader = 16
        ColumnHeader = 32
        [Default] = KeyCancDeleteRow Or RowHeader Or ColumnHeader
    End Enum
End Class

' Grid Alternate Class 
Public Class CommonAlternate
    Inherits SourceGrid2.VisualModels.Common
#Region "Constructors"
    Public Sub New()
        Me.New(False)
    End Sub
    Public Sub New(ByVal p_bReadOnly As Boolean)
        MyBase.New(p_bReadOnly)
    End Sub
    Public Sub New(ByVal p_Source As CommonAlternate, ByVal p_bReadOnly As Boolean)
        MyBase.New(p_Source, p_bReadOnly)
        m_BackColor2 = p_Source.m_BackColor2
    End Sub
#End Region

    Private m_BackColor2 As Color = Color.Gray
    Public Property BackColor2() As Color
        Get
            Return m_BackColor2
        End Get
        Set(ByVal value As Color)
            m_BackColor2 = value
        End Set
    End Property

    Protected Overloads Overrides Sub DrawCell_Background(ByVal p_Cell As SourceGrid2.Cells.ICellVirtual, ByVal p_CellPosition As SourceGrid2.Position, ByVal e As PaintEventArgs, ByVal p_ClientRectangle As Rectangle)
        Dim backColor As Color = backColor
        If p_CellPosition.Row Mod 2 = 0 Then
            backColor = BackColor2
        End If

        Using br As New SolidBrush(backColor)
            e.Graphics.FillRectangle(br, p_ClientRectangle)
        End Using
    End Sub

    Public Overloads Overrides Function Clone(ByVal p_bReadOnly As Boolean) As Object
        Return New CommonAlternate(Me, p_bReadOnly)
    End Function
End Class



' SourceGrid2 Style Class 
Public Class SourceGridStyle
    Public Sub New()
        SetSourceGridStyle()
    End Sub

    ' Header 
    Public visualColHeader As SourceGrid2.VisualModels.Header = DirectCast(SourceGrid2.VisualModels.Header.ColumnHeader.Clone(False), SourceGrid2.VisualModels.Header)
    Public visualRowHeader As SourceGrid2.VisualModels.Header = DirectCast(SourceGrid2.VisualModels.Header.RowHeader.Clone(False), SourceGrid2.VisualModels.Header)

    ' Visual Models 
    Public vmAlignCenter As New CommonAlternate()
    Public vmAlignRight As New CommonAlternate()
    Public vmAlignLeft As New CommonAlternate()
    Public vmEditCellCenter As New CommonAlternate()
    Public vmEditCellRight As New CommonAlternate()

    ' Data Model 
    Public dmDataCellString As New SourceGrid2.DataModels.DataModelBase(GetType(String))
    Public dmDataCellDouble As New SourceGrid2.DataModels.DataModelBase(GetType(Double))
    Public dmEditCellString As New SourceGrid2.DataModels.EditorTextBox(GetType(String))
    Public dmEditCellNumber As New SourceGrid2.DataModels.EditorTextBoxNumeric(GetType(Double))

    Private Sub SetSourceGridStyle()
        ' Header style 
        visualColHeader.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleCenter
        visualRowHeader.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleCenter

        ' Visual Model Style 
        vmAlignCenter.BackColor = Color.AliceBlue
        vmAlignCenter.BackColor2 = Color.White
        vmAlignCenter.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleCenter

        vmAlignRight.BackColor = Color.AliceBlue
        vmAlignRight.BackColor2 = Color.White
        vmAlignRight.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleRight

        vmAlignLeft.BackColor = Color.AliceBlue
        vmAlignLeft.BackColor2 = Color.White
        vmAlignLeft.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleLeft

        vmEditCellCenter.BackColor = Color.AliceBlue
        vmEditCellCenter.BackColor2 = Color.White
        vmEditCellCenter.ForeColor = Color.Red
        vmEditCellCenter.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleCenter

        vmEditCellRight.BackColor = Color.AliceBlue
        vmEditCellRight.BackColor2 = Color.White
        vmEditCellRight.ForeColor = Color.Red
        vmEditCellRight.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleRight

        ' Data Model Style 
        dmDataCellString.EnableEdit = False
        dmDataCellString.DefaultValue = ""
        dmDataCellDouble.EnableEdit = False
        dmDataCellDouble.DefaultValue = 0

        dmEditCellString.EnableEdit = True
        dmEditCellString.DefaultValue = ""
        dmEditCellNumber.EnableEdit = True
        dmEditCellNumber.DefaultValue = 0

    End Sub
End Class


' **********************************************************************************************************
'  1. PROJECT  NAME : ZPSS 4 CBL
'  2. FUNCTION NAME :  									
'  3. EXPLAIN       :  
'  4. PROGRAMER     : 																			
'  5. PROGRAM DATE  : 2010.07.06																			
'  6. MODIFY  DATE  :																						
'																										
'     NUM		MODIFY DATE                 MODIFIER                    MODIFY CONTENT											
'     -----------------------------------------------------------------------------------------		
'     1.		2010.07.06		            											
'				2010.11.11                  J,M,W                       																						
'																										
'																										
'																										
'     -----------------------------------------------------------------------------------------		
'  7. NOTE          :																						
'																										
'																										
' **********************************************************************************************************

Imports System
Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Net
Imports System.Net.Sockets

Public Class CMgrDataBase

    Private con As New SqlConnection()
    Private Transaction As SqlTransaction


    Protected Shared _Instance As CMgrDataBase = Nothing  ' Singleton constructer


    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : 
    '''   
    ''' - ARGUMENT : 
    '''   
    ''' - COMMENT  : 14-digit string of the system returns the current time
    '''   
    ''' - RETURN   : NULL
    '''
    '''*********************************************************************************************************
    Public Shared Function GetInstance() As CMgrDataBase
        If _Instance Is Nothing Then
            _Instance = New CMgrDataBase()
        End If
        Return _Instance
    End Function


    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : 
    '''   
    ''' - ARGUMENT : 
    '''   
    ''' - COMMENT  : Connect database (need defined database name)
    '''   
    ''' - RETURN   : NULL
    '''
    '''*********************************************************************************************************
    Public Function Open(ByVal db As String) As Boolean

        Dim connStr As String = "server=172.25.215.17;user id=sa;pwd=pvst123@;DataBase=" + db ' Connection string ' china PC IP        
        'Dim connStr As String = "server=STL_HMI02;user id=sa;pwd=pvst;DataBase=" + db ' Connection string ' china PC IP
        'Dim connStr As String = "server=127.0.0.1;user id=sa;pwd=pvst;DataBase=" + db ' Connection string 'posco ict PC IP
        'Dim connStr As String = "server=192.168.186.55;user id=sa;pwd=z4cascc;DataBase=" + db ' Connection string
        If con.State = ConnectionState.Open Then  ' Check current database connection state
            con.Close()
        End If
        Try  ' Connect database
            con.ConnectionString = connStr
            con.Open()
            dbcondition = True

        Catch e As Exception
            dbcondition = False
            Close()
        End Try
        Return dbcondition
    End Function


    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : 
    '''   
    ''' - ARGUMENT : 
    '''   
    ''' - COMMENT  : Disconnect database
    '''   
    ''' - RETURN   : NULL
    '''
    '''*********************************************************************************************************
    Public Sub Close()
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
    End Sub


    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : 
    '''   
    ''' - ARGUMENT : 
    '''   
    ''' - COMMENT  : Change Database (Define DataBase Name)
    '''   
    ''' - RETURN   : NULL
    '''
    '''*********************************************************************************************************
    Public Function dbChange(ByVal db As String) As Boolean

        If con.State = ConnectionState.Closed Then  ' Check current database connection state

            Open(db)
        End If
        Try   'Change Data base
            con.ChangeDatabase(db)
            dbcondition = True
        Catch e As Exception
            dbcondition = False
            'MessageBox.Show("[ERR] : " + e.Message)
            Return False
        End Try

        Return dbcondition
    End Function



    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : 
    '''   
    ''' - ARGUMENT : 
    '''   
    ''' - COMMENT  : Execute data read 
    '''   
    ''' - RETURN   : NULL
    '''
    '''*********************************************************************************************************
    Public Function ExecuteReader(ByVal sql As String) As SqlDataReader
        Dim reader As SqlDataReader = Nothing
        Try
            If dbcondition = True Then
                Dim command As New SqlCommand(sql, con)
                reader = command.ExecuteReader()
            End If
        Catch ex As Exception
            dbcondition = False
            MessageBox.Show("ExecuteReader Error : " & ex.Message)
        End Try
        Return reader
    End Function


    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : 
    '''   
    ''' - ARGUMENT : 
    '''   
    ''' - COMMENT  : Execute non data query
    '''   
    ''' - RETURN   : NULL
    '''
    '''*********************************************************************************************************
    Public Function ExecuteNonQuery(ByVal sql As String) As Boolean

        Try
            If dbcondition = True Then

                Dim command As New SqlCommand(sql, con)
                Transaction = con.BeginTransaction
                command.Transaction = Transaction
                command.ExecuteNonQuery()
                Transaction.Commit()
            End If
        Catch ex As Exception
            dbcondition = False
            Transaction.Rollback()
            MessageBox.Show("ExecuteNonQuery Error : " & ex.Message)
        End Try
        Return dbcondition

    End Function


    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : 
    '''   
    ''' - ARGUMENT : 
    '''   
    ''' - COMMENT  : get dataset
    '''   
    ''' - RETURN   : NULL
    '''
    '''*********************************************************************************************************
    Public Function ReturnDataTable(ByVal _table As String, ByVal _sql As String) As DataTable

        Dim ds As New DataSet()
        Try
            If dbcondition = True Then

                Dim adapter As New SqlDataAdapter(_sql, con)
                adapter.Fill(ds, _table)
            End If

        Catch ex As Exception
            dbcondition = False
            MessageBox.Show("ReturnDataTable Error : " & ex.Message)
        End Try
        Return ds.Tables(_table)

    End Function


    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : 
    '''   
    ''' - ARGUMENT : 
    '''   
    ''' - COMMENT  : get dataset
    '''   
    ''' - RETURN   : NULL
    '''
    '''*********************************************************************************************************
    Public Function ReturnDataSet(ByVal sql As String) As DataSet

        Dim dataSet As New DataSet()
        Try
            If dbcondition = True Then

                Dim adapter As New SqlDataAdapter(sql, con)
                adapter.Fill(dataSet)
            End If

        Catch ex As Exception
            dbcondition = False          
            Dim fText As New System.IO.StreamWriter("d:\Information.txt", True)
            fText.WriteLine(Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & " ReturnDataSet Error : " & ex.Message)
            fText.Close()
            'MessageBox.Show("ReturnDataSet Error : " & ex.Message)
            MessageBox.Show("NETWORK DISCONECTION!!!")
        End Try
        Return dataSet

    End Function



    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : 
    '''   
    ''' - ARGUMENT : 
    '''   
    ''' - COMMENT  : get datatable 
    '''          Excel transformation of the target table is stored in the shared variable ExcelDataSet.
    '''          * Attention) is the current form ActiveMdiChild dataset to store only the table clear and dispose of the
    '''          1)  ToolStripButton_Click in main event
    '''          2)  Click the lookup button to the form you will need to at the event.
    '''   
    ''' - RETURN   : NULL
    '''
    '''*********************************************************************************************************
    Public Function ReturnExcelDataTable(ByVal _table As String, ByVal _sql As String, ByVal TableName As String) As DataTable

        Try
            If dbcondition = True Then
                Dim adapter As New SqlDataAdapter(_sql, con)
                Dim sql As String
                Dim t_name() As String = TableName.Split(",")
                Dim i As Integer

                adapter.Fill(ExcelDataSet, _table)
                sql = "select a.name, value from sys.extended_properties a join sys.objects  b on  a.major_id=b.object_id where b.name IN ('"

                For i = 0 To t_name.Length - 1

                    Select Case i
                        Case 0
                            sql = sql + t_name(i)
                        Case Else
                            sql = sql + "','" + t_name(i)
                    End Select
                Next
                sql = sql + "')"

                SetExcelDataTable(_table + "Explane", sql)
            End If

        Catch ex As Exception
            dbcondition = False
            MessageBox.Show("ReturnExcelDataTable Error : " & ex.Message)
        End Try
        Return ExcelDataSet.Tables(_table)

    End Function


    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : 
    '''   
    ''' - ARGUMENT : 
    '''   
    ''' - COMMENT  : 
    '''   
    ''' - RETURN   : NULL
    '''
    '''*********************************************************************************************************
    Public Sub SetExcelDataTable(ByVal _table As String, ByVal _sql As String)

        Try
            If dbcondition = True Then
                Dim adapter As New SqlDataAdapter(_sql, con)
                adapter.Fill(ExcelDataSet, _table)
            End If
        Catch ex As Exception
            dbcondition = False
            MessageBox.Show("SetExcelDataTable Error : " & ex.Message)
        End Try
    End Sub

   
End Class


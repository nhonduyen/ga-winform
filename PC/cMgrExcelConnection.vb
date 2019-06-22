Imports System.Data.OleDb

Public Class cMgrExcelConnection
    Public dbcondition As Boolean
    Private dbConnect As New OleDb.OleDbConnection

    Private dbCmd As OleDb.OleDbCommand

    Protected Shared _Instance As cMgrExcelConnection = Nothing  ' Singleton constructer

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
    Public Shared Function GetInstance() As cMgrExcelConnection
        If _Instance Is Nothing Then
            _Instance = New cMgrExcelConnection()
        End If
        Return _Instance
    End Function

    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : 
    '''   
    ''' - ARGUMENT : 
    '''   
    ''' - COMMENT  : Connect Excel 
    '''   
    ''' - RETURN   : NULL
    '''
    '''*********************************************************************************************************
    Public Function Open(ByVal excelFilePath As String) As Boolean


        If dbConnect.State = ConnectionState.Open Then  ' Check current database connection state
            dbConnect.Close()
        End If
        Try  ' Connect database
            dbConnect = New OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & excelFilePath & ";Extended Properties=""Excel 8.0;HDR=Yes;""")
            'dbConnect = New OleDbConnection("Provider = Microsoft.Jet.OLEDB.12.0;" & "Data Source=" & excelFilePath & ";Extended Properties=""Excel 12.0;HDR=Yes;""")
            dbConnect.Open()

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
        If dbConnect.State = ConnectionState.Open Then
            dbConnect.Close()
        End If
    End Sub

    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : 
    '''   
    ''' - ARGUMENT : 
    '''   
    ''' - COMMENT  : Get Datatable
    '''   
    ''' - RETURN   : NULL
    '''
    '''*********************************************************************************************************
    Public Function ReturnExcelDataTable(ByVal strWhere As String) As DataTable
        Dim dbTable As New DataTable

        dbCmd = New OleDb.OleDbCommand(strWhere, dbConnect)
        Try
            If dbcondition = True Then
                dbTable.Load(dbCmd.ExecuteReader)
            End If
        Catch ex As Exception
            dbcondition = False
            _Instance = Nothing
        End Try

        Return dbTable
    End Function




End Class

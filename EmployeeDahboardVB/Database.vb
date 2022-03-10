Imports System.Configuration
Imports System.Data.SqlClient

Public Class Database
    Public Shared Function ExecuteStoredProcedure(ByVal storedProcedureName As String, ByVal cmd As SqlCommand) As DataTable
        Dim dataSet As DataSet = New DataSet()
        Try
            Dim connection As SqlConnection = DBConnection.GetInstance()
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            cmd.Connection = connection
            cmd.CommandText = storedProcedureName
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            adapter.Fill(dataSet)
            If dataSet.Tables.Count > 0 Then
                Return dataSet.Tables(0)
            End If
        Catch e As Exception
            MessageBox.Show(e.Message, "Invalid Database Connection", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
        Return Nothing
    End Function
    Public Shared Function ExecuteStoredProcedure(ByVal storedProcedureName As String) As DataTable
        Dim dataSet As DataSet = New DataSet()
        Try
            Dim connection As SqlConnection = DBConnection.GetInstance()
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            Dim res As SqlDataAdapter = New SqlDataAdapter(storedProcedureName, connection)
            res.Fill(dataSet)
            If dataSet.Tables.Count > 0 Then
                Return dataSet.Tables(0)
            End If
        Catch e As Exception
            MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
        Return Nothing
    End Function
    Public Shared Function IsValidConnection() As Boolean
        Dim connection As SqlConnection = DBConnection.GetInstance()

        Try
            connection.Open()
        Catch e As Exception
            MessageBox.Show(e.Message, "Invalid Database Connection", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Return False
        End Try

        Return True
    End Function
End Class
Public Class DBConnection
    Public Shared _database As System.Data.SqlClient.SqlConnection = Nothing
    Private Sub New()
    End Sub
    Public Shared Function GetInstance() As System.Data.SqlClient.SqlConnection
        If _database Is Nothing Then
            _database = New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        End If
        Return _database
    End Function
End Class


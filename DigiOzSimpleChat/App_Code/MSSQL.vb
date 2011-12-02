Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class MSSQL
    Private m_host As String
    Private m_name As String
    Private m_user As String
    Private m_pass As String

    Public ds As DataSet
    Public da As SqlClient.SqlDataAdapter
    Public dt As New DataTable
    Public cd As SqlClient.SqlCommandBuilder
    Public cb As SqlCommandBuilder
    Public cn As SqlConnection
    Public reader As SqlClient.SqlDataReader
    Public cnString As String
    Public dllversion As String = "1.0.0"
    Public Err As String

    Sub New()
        ' Constructor
    End Sub

    Public Sub SetConnectionString()
        cnString = "Server=" & m_host & ";Database=" & m_name & ";User ID=" & m_user & ";Password=" & m_pass & ";Trusted_Connection=False;"
    End Sub

    Public Sub SetConnectionString(ByVal lsConnectionString As String)
        cnString = lsConnectionString
    End Sub

    Public Sub openConnection()
        cn = New SqlConnection(cnString)
        Try
            cn.Open()
            Err = ""
        Catch ex As SqlException
            Err = ex.Message.ToString()
        End Try
    End Sub

    Public Sub closeConnection()
        cn.Close()
    End Sub

    Public Sub QueryDBDataset(ByVal sql As String)
        Try
            Dim cmd As New SqlCommand(sql, cn)
            da = New SqlDataAdapter(cmd)
            ds = New DataSet
            da.SelectCommand = cmd
            cb = New SqlCommandBuilder(da)
            da.Fill(ds)
        Catch ex As SqlException
            Throw ex
        End Try
    End Sub

    Public Function QueryDBReader(ByVal sql As String) As SqlClient.SqlDataReader
        reader = Nothing

        Dim cmd As New SqlCommand(sql, cn)
        Try
            reader = cmd.ExecuteReader()
        Catch ex As SqlException
            Throw ex
        Finally
            If Not reader Is Nothing Then reader.Close()
        End Try

        Return reader
    End Function

    Public Function ExecDBScalar(ByVal sql As String) As String
        Dim cmd As New SqlCommand(sql, cn)
        Dim strReturn As String = ""

        Try
            strReturn = cmd.ExecuteScalar() ' .ToString()
        Catch ex As SqlException
            strReturn = ""
        End Try
        Return strReturn
    End Function

    Public Sub ExecuteDBQuery(ByVal sql As String)
        Try
            Dim cmd As New SqlCommand(sql, cn)
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Throw ex
        End Try
    End Sub

    Public Sub UpdateDBDataset()
        Try
            dt = ds.Tables(0)
            Dim changes As DataTable = dt.GetChanges()

            da.Update(changes)
            dt.AcceptChanges()
        Catch ex As SqlException
            Throw ex
        End Try
    End Sub

    Public Sub DeleteDBDatasetRow(ByVal primarykey As String)
        If IsNumeric(primarykey) And CInt(primarykey) >= 0 Then
            Try
                ds.Tables(0).Rows(primarykey).Delete()
                Me.UpdateDBDataset()
            Catch ex As SqlException
                Throw ex
            End Try
        End If
    End Sub

    Public Sub CreateDatabase(ByVal DatabaseName As String)
        Try
            Me.ExecuteDBQuery("CREATE DATABASE " & DatabaseName & ";")
        Catch ex As SqlException
            Throw ex
        End Try
    End Sub

#Region "Public Properties"

    Public Property dbhost() As String
        Get
            dbhost = m_host
        End Get
        Set(ByVal value As String)
            m_host = value
        End Set
    End Property

    Public Property dbname() As String
        Get
            dbname = m_name
        End Get
        Set(ByVal value As String)
            m_name = value
        End Set
    End Property

    Public Property dbuser() As String
        Get
            dbuser = m_user
        End Get
        Set(ByVal value As String)
            m_user = value
        End Set
    End Property

    Public Property dbpass() As String
        Get
            dbpass = m_pass
        End Get
        Set(ByVal value As String)
            m_pass = value
        End Set
    End Property

#End Region

End Class




Partial Class ChatWindow
    Inherits System.Web.UI.Page

    Public csRefresh As String = Nothing
    Public csConnectionString As String = ConfigurationManager.ConnectionStrings("digiozsimplechatconnectionstring").ConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim loMSSQL As New MSSQL()
        Dim lsSQL As String = String.Empty
        Dim lsSQL2 As String = String.Empty
        Dim lsChatText As String = String.Empty

        If Not IsNothing(Session("username")) Then
            csRefresh = "<meta http-equiv=""refresh"" content=""5"">"
        Else
            csRefresh = "<meta http-equiv=""refresh"" content=""300"">"
            Exit Sub
        End If

        'lsChatText = txtChat.Text
        'lsChatText = ConvertHtmlToPlainText(lsChatText)

        lsSQL = "SELECT TOP 50 [username],[message] FROM [tblMessages] ORDER BY [id] DESC;"
        lsSQL2 = "EXEC UpdateUserOnline '" & Session("username") & "';"

        With loMSSQL
            .SetConnectionString(csConnectionString)
            .openConnection()
            .QueryDBDataset(lsSQL)
            .ExecuteDBQuery(lsSQL2)
        End With

        For i As Integer = loMSSQL.ds.Tables(0).Rows.Count - 1 To 0 Step -1
            lsChatText &= "[" & loMSSQL.ds.Tables(0).Rows(i).Item(0).ToString() & "]: " & _
                          loMSSQL.ds.Tables(0).Rows(i).Item(1).ToString() & vbNewLine
        Next

        lsSQL = "SELECT [username] FROM [tblUsersOnline];"

        loMSSQL.QueryDBDataset(lsSQL)
        lblUsers.Text = String.Empty

        For i As Integer = 0 To loMSSQL.ds.Tables(0).Rows.Count - 1
            lblUsers.Text &= "&nbsp;&nbsp;" & loMSSQL.ds.Tables(0).Rows(i).Item(0).ToString() & "<br />"
        Next

        loMSSQL.closeConnection()
        txtMessages.Text = lsChatText
    End Sub
End Class

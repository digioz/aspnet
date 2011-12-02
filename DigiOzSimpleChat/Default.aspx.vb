
Partial Class _Default
    Inherits System.Web.UI.Page

    Public csConnectionString As String = ConfigurationManager.ConnectionStrings("digiozsimplechatconnectionstring").ConnectionString

    Private Function ConvertHtmlToPlainText(ByVal psHTMLText As String) As String
        Dim lsOutput As String = psHTMLText
        lsOutput = Regex.Replace(psHTMLText, "<[^>]*>", String.Empty)
        lsOutput = Replace(lsOutput, "'", "''")
        'lsOutput = Replace(lsOutput, """", "&#34;")
        Return lsOutput
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsNothing(Session("username")) Then
            txtUsername.Visible = False
            btnSignIn.Visible = False
            txtChat.Enabled = True
            btnChat.Enabled = True
        Else
            txtUsername.Visible = True
            btnSignIn.Visible = True
            txtChat.Enabled = False
            btnChat.Enabled = False
            Exit Sub
        End If
    End Sub

    Protected Sub btnChat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChat.Click
        Dim loMSSQL As New MSSQL()
        Dim lsSQL As String = String.Empty
        Dim lsChatText As String = String.Empty

        lsChatText = txtChat.Text
        lsChatText = ConvertHtmlToPlainText(lsChatText)

        If Not lsChatText = String.Empty Then
            lsSQL = "EXEC InsertChatMessage '" & Session("username") & "','" & lsChatText & "';"

            With loMSSQL
                .SetConnectionString(csConnectionString)
                .openConnection()
                .ExecuteDBQuery(lsSQL)
                .closeConnection()
            End With

            txtChat.Text = String.Empty
        End If
    End Sub

    Protected Sub btnSignIn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSignIn.Click
        Dim loMSSQL As New MSSQL()
        Dim lsSQL As String = String.Empty
        Dim lsUsername As String = ConvertHtmlToPlainText(txtUsername.Text)

        If Not lsUsername = String.Empty Then
            lsSQL = "EXEC UpdateUserOnline '" & lsUsername & "';"

            With loMSSQL
                .SetConnectionString(csConnectionString)
                .openConnection()
                .ExecuteDBQuery(lsSQL)
                .closeConnection()
            End With

            Session("username") = lsUsername
            Response.Redirect("Default.aspx")
        End If
    End Sub
End Class

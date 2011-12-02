<%@ Page Language="VB" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" validateRequest="false" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>DigiOz Simple Chat</title>
    <script language="javascript">
        function CheckKey() {
            if (event.keyCode == 13) 
            {
                document.getElementById("btnChat").focus();
            }
        }
    </script>
</head>
<body onkeydown="CheckKey(event);">
    <form id="form1" runat="server">
    <div>
    <center>
        Simple Chat<br />
        <br />
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        <asp:Button ID="btnSignIn" runat="server" BackColor="#8080FF" Text="Sign In" /><br />
        <br />
        <iframe src="ChatWindow.aspx" width="660" height="400" frameborder="0"></iframe>
        <table>
            <tr>
                <td style="height: 19px">
                    <asp:TextBox ID="txtChat" runat="server" BackColor="Silver" Width="512px"></asp:TextBox>
                </td>
                <td style="height: 19px">
                    <asp:Button ID="btnChat" runat="server" Text="Chat" Width="112px" BackColor="#8080FF" />
                </td>
            </tr>
        </table>
        <br />
        <asp:HyperLink ID="hypCopyright" runat="server" Font-Size="Small" NavigateUrl="http://www.digioz.com">DigiOz Simple Chat Version 1.0<br />&#169; DigiOz Multimedia 2009</asp:HyperLink>
        </center>
        </div>
    </form>
</body>
</html>

<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ChatWindow.aspx.vb" Inherits="ChatWindow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Chat Window</title>
    <%= csRefresh %>
    <script language="JavaScript" type="text/javascript">
    function ScrollDown()
    {
        document.getElementById("txtMessages").scrollTop = document.getElementById("txtMessages").scrollHeight;
    }
    </script>
</head>
<body onload="ScrollDown();">
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <asp:TextBox ID="txtMessages" runat="server" BackColor="#E0E0E0" Height="352px" ReadOnly="True"
                        TextMode="MultiLine" Width="512px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblUsers" runat="server" BackColor="#C0C0FF" BorderColor="Black" BorderStyle="Solid"
                        BorderWidth="1px" Height="356px" Width="112px"></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="List" %>

<%@ Register Src="custom_controls/PageTitle.ascx" TagName="PageTitle" TagPrefix="uc2" %>
<%@ Register Src="custom_controls/Footer.ascx" TagName="Footer" TagPrefix="uc3" %>

<%@ Register Src="custom_controls/TopMenu.ascx" TagName="TopMenu" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>DigiOz .NET Guestbook Version 1.1 - Message List</title>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="-1" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
            &nbsp;<uc2:PageTitle ID="PageTitle1" runat="server" />
        </center>
        <center>
            &nbsp;</center>
        <center>
            <uc1:TopMenu ID="TopMenu1" runat="server" />
        </center>
        <br />
        <center>
            <div>
                <asp:Label ID="MsgDisplay" runat="server" Text=""></asp:Label><br />
                <br />
                <asp:Label ID="lblNavigation" runat="server"></asp:Label>&nbsp;</div>
        </center>
        <br />
        <center><uc3:Footer ID="Footer1" runat="server" /></center>
    </div>
    </form>
</body>
</html>

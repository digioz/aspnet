<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<%@ Register Src="custom_controls/Footer.ascx" TagName="Footer" TagPrefix="uc3" %>

<%@ Register Src="custom_controls/TopMenu.ascx" TagName="TopMenu" TagPrefix="uc2" %>

<%@ Register Src="custom_controls/PageTitle.ascx" TagName="PageTitle" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>DigiOz .NET Guestbook Version 1.1 - Add Entry</title>
</head>
<body>
<center><uc1:PageTitle ID="PageTitle1" runat="server" /></center>
<br />
<center><uc2:TopMenu ID="TopMenu1" runat="server" />
    &nbsp;</center>
    <center>

        &nbsp;</center>
<center>
    <form id="form1" runat="server">
    <div>
        <asp:Login ID="AdminLoginControl" runat="server" 
            onauthenticate="AdminLoginControl_Authenticate"></asp:Login>
        <br />
        <asp:Label ID="MsgDisplay" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblNavigation" runat="server"></asp:Label>
    </div>
    </form>
</center>
<center>
        <uc3:Footer ID="Footer1" runat="server" />
</center>
</body>
</html>

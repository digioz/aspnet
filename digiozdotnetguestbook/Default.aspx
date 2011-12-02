<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" ValidateRequest="false" %>
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
        <asp:Label ID="lblResponse" runat="server" Height="24px" Width="496px"></asp:Label>&nbsp;</center>
<center>
<form id="form1" runat="server">
<table border="0" cellpadding="0" cellspacing="0" width="500" style="height: 323px; border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid;">
<tr>
    <td style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px; padding-top: 0px; height: 20px; background-position: left top; background-image: url(images/toolbar.jpg); width: 500px;"></td>
</tr>
<tr>
    <td style="height: 0px; padding-right: 0px; padding-left: 0px; padding-bottom: 0px; padding-top: 0px; width: 500px; background-color: #E6E4E4;">
			<center>
            <asp:Table ID="tblSmilies" runat="server" CellPadding="5" CellSpacing="5">
                <asp:TableRow ID="TableRow1" runat="server">
                    <asp:TableCell ID="TableCell1" runat="server"><asp:ImageButton ID="img_arrow" runat="server" ImageUrl="~/images/icon_arrow.gif" AlternateText=":arrow:" OnClick="Smiley_Click" /></asp:TableCell>
                    <asp:TableCell ID="TableCell2" runat="server"><asp:ImageButton ID="img_biggrin" runat="server" ImageUrl="images/icon_biggrin.gif" AlternateText=":D" OnClick="Smiley_Click" /></asp:TableCell>
                    <asp:TableCell ID="TableCell3" runat="server"><asp:ImageButton ID="img_confused" runat="server" ImageUrl="images/icon_confused.gif" AlternateText=":?" OnClick="Smiley_Click" /></asp:TableCell>
                    <asp:TableCell ID="TableCell4" runat="server"><asp:ImageButton ID="img_cool" runat="server" ImageUrl="images/icon_cool.gif" AlternateText="8)" OnClick="Smiley_Click" /></asp:TableCell>
                    <asp:TableCell ID="TableCell5" runat="server"><asp:ImageButton ID="img_cry" runat="server" ImageUrl="images/icon_cry.gif" AlternateText=":cry:" OnClick="Smiley_Click" /></asp:TableCell>
                    <asp:TableCell ID="TableCell6" runat="server"><asp:ImageButton ID="img_eek" runat="server" ImageUrl="images/icon_eek.gif" AlternateText=":shock:" OnClick="Smiley_Click" /></asp:TableCell>
                    <asp:TableCell ID="TableCell7" runat="server"><asp:ImageButton ID="img_evil" runat="server" ImageUrl="images/icon_evil.gif" AlternateText=":evil:" OnClick="Smiley_Click" /></asp:TableCell>
                    <asp:TableCell ID="TableCell8" runat="server"><asp:ImageButton ID="img_exclaim" runat="server" ImageUrl="images/icon_exclaim.gif" AlternateText=":!:" OnClick="Smiley_Click" /></asp:TableCell>
                    <asp:TableCell ID="TableCell9" runat="server"><asp:ImageButton ID="img_frown" runat="server" ImageUrl="images/icon_frown.gif" AlternateText=":(" OnClick="Smiley_Click" /></asp:TableCell>
                    <asp:TableCell ID="TableCell10" runat="server"><asp:ImageButton ID="img_idea" runat="server" ImageUrl="images/icon_idea.gif" AlternateText=":idea:" OnClick="Smiley_Click" /></asp:TableCell>
                    <asp:TableCell ID="TableCell11" runat="server"><asp:ImageButton ID="img_lol" runat="server" ImageUrl="images/icon_lol.gif" AlternateText=":lol:" OnClick="Smiley_Click" /></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow2" runat="server">
                    <asp:TableCell ID="TableCell12" runat="server"><asp:ImageButton ID="img_mad" runat="server"  ImageUrl="images/icon_mad.gif" AlternateText=":x" OnClick="Smiley_Click" /></asp:TableCell>
                    <asp:TableCell ID="TableCell13" runat="server"><asp:ImageButton ID="img_mrgreen" runat="server"  ImageUrl="images/icon_mrgreen.gif" AlternateText=":green:" OnClick="Smiley_Click" /></asp:TableCell>
                    <asp:TableCell ID="TableCell14" runat="server"><asp:ImageButton ID="img_neutral" runat="server" ImageUrl="images/icon_neutral.gif" AlternateText=":|" OnClick="Smiley_Click" /></asp:TableCell>
                    <asp:TableCell ID="TableCell15" runat="server"><asp:ImageButton ID="img_question" runat="server" ImageUrl="images/icon_question.gif" AlternateText=":question:" OnClick="Smiley_Click" /></asp:TableCell>
                    <asp:TableCell ID="TableCell16" runat="server"><asp:ImageButton ID="img_razz" runat="server" ImageUrl="images/icon_razz.gif" AlternateText=":P" OnClick="Smiley_Click" /></asp:TableCell>
                    <asp:TableCell ID="TableCell17" runat="server"><asp:ImageButton ID="img_redface" runat="server" ImageUrl="images/icon_redface.gif" AlternateText=":oops:" OnClick="Smiley_Click" /></asp:TableCell>
                    <asp:TableCell ID="TableCell18" runat="server"><asp:ImageButton ID="img_rolleyes" runat="server" ImageUrl="images/icon_rolleyes.gif" AlternateText=":roll:" OnClick="Smiley_Click" /></asp:TableCell>
                    <asp:TableCell ID="TableCell19" runat="server"><asp:ImageButton ID="img_smile" runat="server" ImageUrl="images/icon_smile.gif" AlternateText=":)" OnClick="Smiley_Click" /></asp:TableCell>
                    <asp:TableCell ID="TableCell20" runat="server"><asp:ImageButton ID="img_surprised" runat="server" ImageUrl="images/icon_surprised.gif" AlternateText=":o" OnClick="Smiley_Click" /></asp:TableCell>
                    <asp:TableCell ID="TableCell21" runat="server"><asp:ImageButton ID="img_twisted" runat="server" ImageUrl="images/icon_twisted.gif" AlternateText=":twisted:" OnClick="Smiley_Click" /></asp:TableCell>
                    <asp:TableCell ID="TableCell22" runat="server"><asp:ImageButton ID="img_wink" runat="server" ImageUrl="images/icon_wink.gif" AlternateText=":wink:" OnClick="Smiley_Click" /></asp:TableCell>  
                </asp:TableRow>
            </asp:Table>
			</center>
            <table style="width: 455px">
                    <tr>
                        <td style="width: 195px">
                            <asp:Label ID="lblyourname" runat="server" Font-Bold="True">Your Name:</asp:Label></td>
                        <td style="width: 315px" align="left"><asp:TextBox ID="yourname" runat="server" Width="310px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 195px">
                            <asp:Label ID="lblyouremail" runat="server" Font-Bold="True">Your Email:</asp:Label></td>
                        <td style="width: 315px" align="left"><asp:TextBox ID="youremail" runat="server" Width="310px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 195px; height: 11px;">
                            <asp:Label ID="lblVerifyCode" runat="server" Font-Bold="True" Visible="False">Verify Code:</asp:Label></td>
                        <td style="width: 315px; height: 11px;" align="left">
                            <asp:TextBox ID="txtVerifyCode" runat="server" Visible="False" Width="210px"></asp:TextBox>
                            <asp:Image ID="ImgVerifyCode" runat="server" Visible="False" Width="90px" Height="20px" /></td>
                    </tr>
                    <tr>
                        <td style="width: 195px">
                            <asp:Label ID="lblyourmessage" runat="server" Font-Bold="True">Your Message:</asp:Label></td>
                        <td style="width: 315px" align="left"><asp:TextBox ID="yourmessage" runat="server" Height="142px" TextMode="MultiLine" Width="310px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2" align="right" style="height: 22px">
                            <asp:Button ID="btnAdd" runat="server" Height="20px" Text="Submit" 
                                Width="100px" BackColor="LightSteelBlue" Font-Bold="True" 
                                onclick="btnAdd_Click" /></td>
                    </tr>
            </table>
            <br />
        </td>
    </tr>               
</table>
</form>
</center>
<center>
        <uc3:Footer ID="Footer1" runat="server" />
</center>
</body>
</html>

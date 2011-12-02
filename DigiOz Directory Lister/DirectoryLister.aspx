<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="DirectoryLister.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>DigiOz Directory Lister</title>
    <link href="style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <asp:Label ID="lblTitle" runat="server" Text="DigiOz Directory Lister" Font-Size="16pt" Font-Underline="True"></asp:Label></div>
        <br />
        &nbsp;<br />
        <asp:GridView ID="GridViewFiles" runat="server" CssClass="gridrows" Height="144px" HorizontalAlign="Center" Width="600px" AutoGenerateColumns="False">
            <HeaderStyle CssClass="gridheader" BorderWidth="1px" />
            <Columns>
                <asp:TemplateField HeaderText="File Name">
                    <ItemTemplate>
                        <div align="left">
                            <a href="./<%=csRelativePath%>/<%# Eval("FileName","{0}") %>"><%# Eval("FileName","{0}") %></a>
                        </div>      
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date Created">
                    <ItemTemplate>
                        <div align="right">
                            <%# Eval("DateCreated", "{0:d/M/yyyy HH:mm:ss}")%>
                        </div>    
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date Modified">
                    <ItemTemplate>
                        <div align="right">
                            <%# Eval("DateModified", "{0:d/M/yyyy HH:mm:ss}")%>  
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Size">
                    <ItemTemplate>
                        <div align="right">
                            <%# Eval("Size", "{0:0}")%> KB 
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <div align="center">
            <asp:HyperLink ID="hypCopyright" runat="server" Font-Size="Small" NavigateUrl="http://www.digioz.com">DigiOz Directory Lister Version 1.1<br />&#169; DigiOz Multimedia 2009</asp:HyperLink>
        </div>
    </form>
</body>
</html>

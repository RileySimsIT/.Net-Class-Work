<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Catalog.aspx.cs" Inherits="Riley_eCommerce.Catalog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Catalog</title>
    <link href="Styles/Catalog.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Catalog" CssClass="Label"></asp:Label>
        <asp:Table ID="Table1" CssClass="CellStyle" Height="223px" runat="server" style="position:absolute; top:100px;"></asp:Table>
        <asp:Button ID="Button1" runat="server" style="visibility:hidden; color:white; background:red;" Text="Button" OnClick="Button1_Click"/>
    </div>
    </form>
</body>
</html>


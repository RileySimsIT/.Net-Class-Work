<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Riley_eCommerce.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reslife Store</title>
    <link href="Styles/Default.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ImageButton ID="imgLogo" CssClass="Logo" runat="server" ImageUrl="~/images/FanshaweLogo.png" OnClick="imgLogo_Click"  />
        <asp:Panel ID="Panel1" runat="server">
            <asp:Button ID="btnPromo" runat="server" CssClass="Buttons" Style="left:22%; width:10%;top:2%;" Text="Promo Page" OnClick="btnPromo_Click" />
            <asp:Button ID="btnCatalog" runat="server" CssClass="Buttons" Style="left:33%; width:10%; top:2%;" Text="Catalog" OnClick="btnCatalog_Click" />
            <asp:Button ID="btnCart" runat="server" CssClass="Buttons" Style="left:44%; width:10%; top:2%;" Text="Cart" OnClick="btnCart_Click" />
            <asp:Button ID="btnWeather" runat="server" CssClass="Buttons" Style="left:55%; width:10%; top:2%;" Text="Weather" OnClick="btnWeather_Click" />
            <asp:Button ID="btnCustomers" runat="server" CssClass="Buttons" Style="left:66%; width:10%; top:2%;" Text="Customers" OnClick="btnCustomers_Click" />
            <asp:Button ID="btnProducts" runat="server" CssClass="Buttons" Style="left:77%; width:10%; top:2%;" Text="Products" OnClick="btnProducts_Click" />
        </asp:Panel>
        <iframe id="myFrame" class="MainFrame" src="MainPage.aspx" runat="server"> </iframe>
    </div>
    </form>
</body>
</html>

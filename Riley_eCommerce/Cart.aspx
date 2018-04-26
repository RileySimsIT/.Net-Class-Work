<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Riley_eCommerce.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/Cart.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table ID="Table1" runat="server" CssClass="CellStyle" Height="223px" style="top:60px;" BackColor="#Fc5b3f" BorderStyle="Double"></asp:Table>
        
        <asp:Button ID="btnRecalculate" runat="server" CssClass="Button" Text="Recalculate Total" OnClick="btnRecalculate_Click" style="left:1%;" />
        <asp:Button ID="btnCheckOut" runat="server" CssClass="Button" Text="Checkout" OnClick="btnCheckOut_Click" style="left:8%;"  />
        <asp:Label ID="LblTotal" runat="server" CssClass="Label" Text="0.00" style="left:13%;"></asp:Label>
    </div>
    </form>
</body>
</html>

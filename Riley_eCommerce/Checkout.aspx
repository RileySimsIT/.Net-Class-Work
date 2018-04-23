<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="Riley_eCommerce.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Checkout</title>
    <link href="Styles/Checkout.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <iframe id="CustomerFrame" class="CheckoutFrame" src="Customers.aspx" runat="server"
            style="left: 5%; top:80px">
        </iframe>
        <iframe id="DetailFrame" class="CheckoutFrame" src="Details.aspx" runat="server"
            style="right: 5%; top:80px">
        </iframe>
    </div>
    </form>
</body>
</html>

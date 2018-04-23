<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="Riley_eCommerce.Details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Details</title>
    <link href="Styles/Details.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table ID="Table1" runat="server" CssClass="CellStyle" style="top:30px;"></asp:Table>
        <asp:Label ID="LblTotal" runat="server" CssClass="Label" Text="0.00"></asp:Label>
        <asp:CheckBox ID="ChkMailingList" runat="server" CssClass="Checkboxes" AutoPostback="false" Text="Add me to the Mailing List" OnCheckedChanged="AddMe" />
        <asp:Button ID="BtnPay" runat="server" Text="Pay for my Order" CssClass="Buttons" OnClick="PayForOrder" />
    </div>
    </form>
</body>
</html>

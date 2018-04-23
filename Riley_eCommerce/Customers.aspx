<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="Riley_eCommerce.Customers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customers</title>
    <link href="Styles/Customers.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <asp:Label ID="lblCustomerNumber" CssClass="Labels" style="left: 10px; top: 20px" runat="server" Text="Customer #"></asp:Label>
            <asp:TextBox ID="txtCustomerNumber" CssClass="TextBoxes" style="top: 20px; left: 170px; width: 111px; color:red" runat="server"></asp:TextBox>

            <asp:Label ID="lblFirstName" CssClass="Labels" style="left: 10px; top: 50px" runat="server" Text="First Name"></asp:Label>
            <asp:TextBox ID="txtFirstName" CssClass="TextBoxes" style="left: 170px; top: 50px; width: 200px" runat="server"></asp:TextBox>

            <asp:Label ID="lblLastName" CssClass="Labels" style="left: 10px; top: 80px" runat="server" Text="Last Name"></asp:Label>
            <asp:TextBox ID="txtLastName" CssClass="TextBoxes" style="left: 170px; top: 80px; width: 200px" runat="server"></asp:TextBox>

            <asp:Label ID="lblAddress" CssClass="Labels" style="left: 10px; top: 110px" runat="server" Text="Address"></asp:Label>
            <asp:TextBox ID="txtAddress" CssClass="TextBoxes" style="left: 170px; top: 110px; width: 200px" runat="server"></asp:TextBox>

            <asp:Label ID="lblCity" CssClass="Labels" style="left: 10px; top: 140px" runat="server" Text="City"></asp:Label>
            <asp:TextBox ID="txtCity" CssClass="TextBoxes" style="left: 170px; top: 140px; width: 120px" runat="server"></asp:TextBox>

            <asp:Label ID="lblProvince" CssClass="Labels" style="left: 10px; top: 170px" runat="server" Text="Province"></asp:Label>
            <asp:TextBox ID="txtProvince" CssClass="TextBoxes" style="left: 170px; top: 170px; width: 120px" runat="server"></asp:TextBox>

            <asp:Label ID="lblPostal" CssClass="Labels" style="left: 10px; top: 200px" runat="server" Text="Postal"></asp:Label>
            <asp:TextBox ID="txtPostal" CssClass="TextBoxes" style="left: 170px; top: 200px; width: 120px" runat="server"></asp:TextBox>
                <ul>
                    <li><asp:Button ID="btnNewCustomer" CssClass="Buttons" runat="server" style="left:10px;" Text="New" ToolTip="Create a new customer" OnClick="btnNewCustomer_Click" /></li>
                    <li><asp:Button ID="btnAddCustomer" CssClass="Buttons" runat="server" style="left:140px;" Text="Add" ToolTip="Add the Customer to the database" OnClick="btnAddCustomer_Click" /></li>
                    <li><asp:Button ID="btnUpdateCustomer" CssClass="Buttons" runat="server" style="left:270px;" Text="Update" ToolTip="Update the Customer" Enabled="False" OnClick="btnUpdateCustomer_Click" /></li>
                    <li><asp:Button ID="btnDeleteCustomer" CssClass="Buttons" runat="server" style="left:400px;" Text="Delete" ToolTip="Delete the Customer" Enabled="False" OnClick="btnDeleteCustomer_Click" /></li>
                    <li><asp:Button ID="btnFindCustomer" CssClass="Buttons" runat="server" style="left:530px;" Text="Find" ToolTip="Find a customer" OnClick="btnFindCustomer_Click"/></li>
                </ul>
            <asp:Label ID="lblMessages" runat="server" CssClass="Labels" style="top:250px; width:50px; left:18%; font-size:20pt; height: 4%;" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>

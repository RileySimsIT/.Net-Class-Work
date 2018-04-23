<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Riley_eCommerce.Products" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Products</title>
    <link href="Styles/Products.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panel1" CssClass="Panels" style="left:10px; top:100px; height:580px; right:5px;" runat="server">

            <asp:Label ID="lblPicture" CssClass="Labels" style="left:10px; top:80px;" runat="server" Text="Picture"></asp:Label>
            <asp:TextBox ID="txtPicture" CssClass="TextBoxes" style="left:250px; top:80px;" runat="server"></asp:TextBox>

            <asp:Label ID="lblProductId" CssClass="Labels" style="left:10px; top:120px;" runat="server" Text="Product ID"></asp:Label>
            <asp:TextBox ID="txtProductID" CssClass="TextBoxes" style="left:250px; top:120px;" runat="server"></asp:TextBox>

            <asp:Label ID="lblManufacturerCode" CssClass="Labels" style="left:10px; top:160px;" runat="server" Text="Manufacturer Code"></asp:Label>
            <asp:TextBox ID="txtManufacturerCode" CssClass="TextBoxes" style="left:250px; top:160px;" runat="server"></asp:TextBox>

            <asp:Label ID="lblDescription" CssClass="Labels" style="left:10px; top:200px;" runat="server" Text="Description"></asp:Label>
            <asp:TextBox ID="txtDescription" CssClass="TextBoxes" style="left:250px; top:200px;" runat="server"></asp:TextBox>

            <asp:Label ID="lblQOH" CssClass="Labels" style="left:10px; top:240px;" runat="server" Text="Quantity on Hand"></asp:Label>
            <asp:TextBox ID="txtQOH" CssClass="TextBoxes" style="left:250px; top:240px;" runat="server"></asp:TextBox>

            <asp:Label ID="lblPrice" CssClass="Labels" style="left:10px; top:280px;" runat="server" Text="Price"></asp:Label>
            <asp:TextBox ID="txtPrice" CssClass="TextBoxes" style="left:250px; top:280px;" runat="server"></asp:TextBox>
            
            <asp:Button ID="btnNewProduct" CssClass="Buttons" style="left:10px; bottom:10px; width:100px;" runat="server" Text="New" OnClick="btnNewProduct_Click" />
            <asp:Button ID="btnAdd" CssClass="Buttons" style="left:120px; bottom:10px; width:100px;" runat="server" Text="Add" OnClick="btnAdd_Click" />
            <asp:Button ID="btnUpdate" CssClass="Buttons" style="left:230px; bottom:10px; width:100px;" runat="server" Text="Update" Enabled="False" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnDelete" CssClass="Buttons" style="left:340px; bottom:10px; width:100px;" runat="server" Text="Delete" Enabled="False" OnClick="btnDelete_Click" />
            <asp:Button ID="btnFind" CssClass="Buttons" style="left:450px; bottom:10px; width:100px;" runat="server" Text="Find" OnClick="btnFind_Click"  />
            <asp:Button ID="btnUpload" CssClass="Buttons" style="left:560px; bottom:10px; width:100px;" runat="server" Text="Upload" OnClick="btnUpload_Click" />

            <asp:FileUpload ID="ImageFileUpload" CssClass="Buttons" style="left:1269px; bottom:40px; width:520px;" runat="server" />
            <asp:Image ID="imgUploaded" CssClass="Images" style="left:1270px; bottom:80px; height:480px; width:520px;" runat="server" />

            <asp:Label ID="lblMessages" runat="server" CssClass="Labels" style="top:590px; height:16px; width:100%; background-color:white" Text=""></asp:Label>
        </asp:Panel>
    </div>
    </form>
</body>
</html>

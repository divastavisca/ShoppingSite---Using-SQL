<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductManipulation.aspx.cs" Inherits="ShoppingSite.Entry.ProductManipulation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Table ID="TableProducts" runat="server" Width="100%" BorderStyle="Groove">
                <asp:TableRow>
                    <asp:TableCell>ProductName</asp:TableCell>
                    <asp:TableCell>Price</asp:TableCell>
                    <asp:TableCell>Quantity</asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <div>
                <asp:LinkButton ID="LinkButtonAddProduct" runat="server" PostBackUrl="AddProduct.aspx">Add Product</asp:LinkButton>
            </div>
        </div>
    </form>
</body>
</html>

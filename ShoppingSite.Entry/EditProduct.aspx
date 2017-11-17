<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="ShoppingSite.Entry.EditProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="editForm" runat="server">
            <div>
                <h1 runat="server" id="heading">Edit Product</h1>
                <div>
                    <asp:Table ID="TableEditPanel" runat="server">
                        <asp:TableRow>
                            <asp:TableCell Text="Product Id">
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="TextBoxProductId" runat="server" Enabled="false"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Text="Product Name">
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="TextBoxProductName" runat="server"></asp:TextBox>
                            </asp:TableCell>
<%--                            <asp:TableCell>
                                <asp:RequiredFieldValidator ControlToValidate="ProductName" ID="ProductNameValidator" runat="server" ErrorMessage="Required">
                                </asp:RequiredFieldValidator>
                            </asp:TableCell>--%>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Text="Quantity">
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="TextBoxQuantity" runat="server"></asp:TextBox>
                            </asp:TableCell>
<%--                            <asp:TableCell>
                                <asp:RequiredFieldValidator ControlToValidate="Quantity" ID="QuantityValidator" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                            </asp:TableCell>--%>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Text="Price">
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="TextBoxPrice" runat="server"></asp:TextBox>
                            </asp:TableCell>
<%--                            <asp:TableCell>
                                <asp:RequiredFieldValidator ControlToValidate="Price" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                            </asp:TableCell>--%>
                        </asp:TableRow>
                    </asp:Table>
                </div>
            </div>
            <div style="margin-top: 30px">
                <span>
                    <asp:Button ID="ButtonSave" runat="server" Text="Save" OnClick="Save_Click" />
                </span>
                <span style="margin-left: 40px">
                    <asp:Button ID="ButtonBack" runat="server" Text="Back" PostBackUrl="~/ProductManipulation.aspx" />
                </span>
            </div>
        </div>
    </form>
</body>
</html>

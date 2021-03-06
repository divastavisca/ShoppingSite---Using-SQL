﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="ShoppingSite.Entry.AddProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Add Product</h1>
        </div>
        <div>
            <asp:Table ID="TableAddProduct" runat="server">
                <asp:TableRow>
                    <asp:TableCell Text="Name"></asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TextBoxProductName" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Text="Quantity"></asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TextBoxQuantity" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Text="Price"></asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TextBoxPrice" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
        <div style="margin-top: 20px">
            <span>
                <asp:Button ID="ButtonAdd" runat="server" Text="Add Product" OnClick="Add_Click" />
            </span>
            <span  style="margin-left: 40px">
                <asp:Button ID="ButtonBack" runat="server" Text="Back" PostBackUrl="~/ProductManipulation.aspx"/>
            </span>
        </div>
        <div style="margin-top:15px">
            <asp:Label ID="LabelDataStatus" runat="server" Visible="false"></asp:Label>
        </div>
    </form>
</body>
</html>

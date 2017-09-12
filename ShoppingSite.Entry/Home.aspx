<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ShoppingSite.Entry.Home" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <asp:Table ID="Products" runat="server" Width="100%" BorderStyle="Groove">
            <asp:TableRow>
                <asp:TableCell>Item</asp:TableCell>
                <asp:TableCell>Price</asp:TableCell>
                <asp:TableCell>Quantity</asp:TableCell>
                <asp:TableCell>Add To Cart</asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <%--<asp:GridView ID="GridPanel" runat="server" AutoGenerateColumns="False" EditRowStyle-VerticalAlign="Middle">
            <Columns>
                <asp:BoundField DataField="Key" HeaderText="Item" ItemStyle-VerticalAlign="Middle" />
                <asp:BoundField DataField="Value" HeaderText="Quantity" ItemStyle-VerticalAlign="Middle" />
                <asp:TemplateField ShowHeader="True">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/img/cart-img.jpg"  runat="server" CausesValidation="false" CommandName="SendMail" EnableViewState="true" OnClick="AddToCart" Height="50px" Width="90px" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>--%>
    </form>
</body>
</html>

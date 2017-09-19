<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="ShoppingSite.Entry.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h1 id="heading" runat="server">Your items are ready to be ordered</h1>
        <asp:Table ID="TableCartContainer" EnableViewState="true" runat="server" BorderStyle="Outset" Font-Italic="True" Font-Size="Larger" HorizontalAlign="Center" Width="70%" Visible="false">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>Item</asp:TableHeaderCell>
                <asp:TableHeaderCell>Quantity</asp:TableHeaderCell>
                <asp:TableHeaderCell>Price</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
        
        <p style="margin-left: 440px">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="AmountLabel" runat="server" Font-Size="Larger" Text="Amount: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Payable" runat="server" Font-Size="Larger"></asp:Label>

        </p>
        <p style="margin-left: 440px">
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

            <asp:Button ID="ButtonContinue" runat="server" Text="Continue Shopping" BorderStyle="Ridge" PostBackUrl="~/Home.aspx" Visible="false"/>

    &nbsp;<asp:Button ID="ButtonPlaceOrder" runat="server" BorderStyle="Ridge" Text="Place Order" Visible="false" OnClick="PlaceOrder_Click" OnClientClick="return confirm(&quot;Are you sure you want to Proceed?&quot;)" />

        </p>

    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlaceOrder.aspx.cs" Inherits="ShoppingSite.Entry.PlaceOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:Label ID="LabelOrderSummary" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="ButtonPay" runat="server" OnClick="Pay_Click"/>
    </form>
</body>
</html>

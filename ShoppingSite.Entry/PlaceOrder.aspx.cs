using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShoppingSite.Core;
using ShoppingSite.Entry.src;

namespace ShoppingSite.Entry
{
    public partial class PlaceOrder : System.Web.UI.Page
    {
        private readonly string _container = "CartContainer";
        private readonly string _totalPrice = "CartReady";
        private readonly string _productIds = "ProductId";
        private readonly string _productPrice = "ProductPrice";
        private readonly string _actualOrder = "ActualOrder";

        protected void Page_Load(object sender, EventArgs e)
        {
            Pay.Visible = false;
            if(Session[_container]==null)
            {
                OrderSummary.Text = "Invalid order request";
            }
            else
            {
                OrderSummary.Text = "Thank you for shopping with us please pay " + Session[_totalPrice].ToString()+".";
                Pay.Visible = true;
                Pay.Text = "Pay " + Session[_totalPrice].ToString();
            }
        }

        protected void Pay_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> productIds = (Dictionary<string, string>)Session[_productIds];
            Dictionary<string, int> productPrice = (Dictionary<string, int>)Session[_productPrice];
            Dictionary<string, int> cartItems = (Dictionary<string, int>)Session[_container];
            Session[_actualOrder] = OrderGenerator.Generate(productIds, productPrice, cartItems, (int)Session[_totalPrice]);
            Response.Redirect("OrderSummary.aspx");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShoppingSite.Core;
using ShoppingSite.Entry.src;
using System.Data.SqlClient;

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
            ButtonPay.Visible = false;
            if(Session[_container]==null)
            {
                LabelOrderSummary.Text = "Invalid order request";
            }
            else
            {
                LabelOrderSummary.Text = "Thank you for shopping with us please pay " + Session[_totalPrice].ToString()+".";
                ButtonPay.Visible = true;
                ButtonPay.Text = "Pay " + Session[_totalPrice].ToString();
            }
        }

        protected void Pay_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> productIds = (Dictionary<string, string>)Session[_productIds];
            Dictionary<string, int> productPrice = (Dictionary<string, int>)Session[_productPrice];
            Dictionary<string, int> cartItems = (Dictionary<string, int>)Session[_container];
            try
            {
                Session[_actualOrder] = OrderGenerator.Generate(productIds, productPrice, cartItems, (int)Session[_totalPrice]);
            }
            catch (SqlException dataBaseException)
            {
                Response.Write("<script>if(confirm('There was some problem loading the data, pls try again later'){window.location='ProductManipulation.aspx';})</script>");
            }
            catch (Exception exception)
            {
                Response.Write("<script>if('Error try again later'){window.location='ProductManipulation.aspx';}</script>");
            }
            Response.Redirect("OrderSummary.aspx");
        }
    }
}
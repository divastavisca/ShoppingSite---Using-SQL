using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShoppingSite.Core;

namespace ShoppingSite.Entry
{
    public partial class OrderSummary : System.Web.UI.Page
    {
        private readonly string _container = "CartContainer";
        private readonly string _totalPrice = "CartReady";
        private readonly string _actualOrder = "ActualOrder";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[_totalPrice] != null)
            {
                Dictionary<string, int> items = (Dictionary<string, int>)Session[_container];
                Order userOrder = (Order)Session[_actualOrder];
                LabelOrderRef.Text = userOrder.OrderId;
                LabelOrderAmount.Text = userOrder.OrderAmount.ToString();
                foreach(KeyValuePair<string,int>item in items)
                {
                    LabelOrderList.Text = LabelOrderList.Text + ", ("+item.Key+") X "+item.Value;
                }
                Session.Clear();
            }
            else Response.Redirect("Home.aspx");
        }
    }
}
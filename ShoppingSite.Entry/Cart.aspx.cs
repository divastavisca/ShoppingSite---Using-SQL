using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShoppingSite.Core;

namespace ShoppingSite.Entry
{
    public partial class Cart : System.Web.UI.Page
    {
        private readonly string _cart = "ShoppingCart";
        private readonly string _productMap = "ProductMap";
        private readonly string _productPrice = "ProductPrice";
        private readonly string _container = "CartContainer";
        private readonly string _totalPrice = "CartReady";
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            AmountLabel.Visible = false;
            Payable.Visible = false;
            if(Session[_cart]==null)
            {
                if (Request.QueryString["pid"] != null)
                {
                    Session[_cart] = new ShoppingCart();
                    Session[_container] = new Dictionary<string, int>();
                    Continue.Text = "Continue Shopping";
                    Continue.Visible = true;
                    PlaceOrder.Visible = true;
                    CartContainer.Visible = true;
                    populateCart();
                }
                else
                {
                    heading.InnerText = "Sorry, at present the cart is empty";
                    Continue.Visible = true;
                    Continue.Text = "Start Shopping";
                }
            }
            else
            {
                Continue.Text = "Continue Shopping";
                Continue.Visible = true;
                PlaceOrder.Visible = true;
                CartContainer.Visible = true;
                populateCart();
            }
        }

        private void populateCart()
        {
            Dictionary<string,int> productMap = (Dictionary<string,int>)Session[_productMap];
            Dictionary<string, int> productPrices = (Dictionary<string, int>)Session[_productPrice];
            Dictionary<string, int> cartItems = (Dictionary<string, int>)Session[_container];
            string querry = Request.QueryString["pid"];
            int totalAmount = 0;
            if (querry != null)
            {
                int productId = Convert.ToInt32(querry);
                string productInfo = string.Empty;
                bool found = false;
                foreach (KeyValuePair<string, int> pair in productMap)
                {
                    if (pair.Value == productId)
                    {
                        productInfo = pair.Key;
                        break;
                    }
                }
                int itemPrice = productPrices[productInfo];
                foreach (string key in cartItems.Keys)
                {
                    if (key == productInfo)
                    {
                        cartItems[key]++;
                        found = true;
                        break;
                    }
                }
                if (found == false)
                {
                    cartItems.Add(productInfo, 1);
                }
            }
            foreach(KeyValuePair<string,int> cartItem in cartItems)
            {
                TableCell info = new TableCell();
                TableCell count = new TableCell();
                TableCell price = new TableCell();
                info.Text = cartItem.Key;
                count.Text = cartItem.Value.ToString();
                int amount = productPrices[cartItem.Key]*cartItem.Value;
                price.Text = amount.ToString();
                TableRow row = new TableRow();
                row.Cells.Add(info);
                row.Cells.Add(count);
                row.Cells.Add(price);
                totalAmount += amount;
                CartContainer.Rows.Add(row);
            }
            AmountLabel.Visible = true;
            AmountLabel.Font.Size = FontUnit.Larger;
            Payable.Font.Size = FontUnit.Larger;
            Payable.Text = totalAmount.ToString();
            Payable.Visible = true;
            Session[_totalPrice] = totalAmount;
        }

        protected void PlaceOrder_Click(object sender, EventArgs e)
        {
            Response.Redirect("PlaceOrder.aspx");
        }
    }
}
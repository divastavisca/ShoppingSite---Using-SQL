using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace ShoppingSite.Entry
{
    public partial class EditProduct : System.Web.UI.Page
    {
        private readonly string _productEdit = "EditProduct";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["pid"]!=null)
            {
                Session[_productEdit] = Request.QueryString["pid"];
            }
            if(Session[_productEdit]!=null)
            {
                ProductId.Text = Session[_productEdit].ToString();
                editForm.Visible = true;
            }
            else
            {
                editForm.Visible = false;
                heading.InnerText = "Invalid Edit Request";
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            string productId = ProductId.Text;
            string productName = ProductName.Text;
            int qty = Convert.ToInt32(Quantity.Text);
            int price = Convert.ToInt32(Price.Text);
            try
            {
                using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbcs"].ToString()))
                {
                    SqlCommand cmd = new SqlCommand("Update Products Set ProductName=@ProductName,Quantity=@Quantity,Price=@Price where ProductId=@ProductId");
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("ProductId", productId);
                    cmd.Parameters.AddWithValue("ProductName", productName);
                    cmd.Parameters.AddWithValue("Quantity", qty);
                    cmd.Parameters.AddWithValue("Price", price);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    Session.Clear();
                    Response.Write("<script>if(confirm('Product Updated')){window.location='ProductManipulation.aspx';}</script>");
                }
            }
            catch (SqlException dataBaseException)
            {
                Response.Write("<script>if(confirm('There was some problem loading the data, pls try again later'){window.location='ProductManipulation.aspx';})</script>");
            }
            catch (Exception exception)
            {
                Response.Write("<script>if('Error try again later'){window.location='ProductManipulation.aspx';}</script>");
            }
        }
    }
}
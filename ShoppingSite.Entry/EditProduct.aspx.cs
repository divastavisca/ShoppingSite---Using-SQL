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
                TextBoxProductId.Text = Session[_productEdit].ToString();
                try
                {
                    DataTable table = new DataTable();
                    using (SqlConnection connnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbcs"].ConnectionString))
                    {
                        SqlCommand command = new SqlCommand("Select * from Products where ProductId=@pid", connnection);
                        command.Parameters.AddWithValue("pid", TextBoxProductId.Text);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(table);
                    }
                    TextBoxProductName.Text = table.Rows[1].ToString();
                    TextBoxQuantity.Text = table.Rows[2].ToString();
                    TextBoxPrice.Text = table.Rows[3].ToString();
                }
                catch(SqlException excep)
                {

                }
                catch(Exception exc)
                {

                }
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
            string productId = TextBoxProductId.Text;
            string productName = TextBoxProductName.Text;
            int qty = Convert.ToInt32(TextBoxQuantity.Text);
            int price = Convert.ToInt32(TextBoxPrice.Text);
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
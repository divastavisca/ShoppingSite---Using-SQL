using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ShoppingSite.Entry
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataStatus.Visible = false;
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            int count = 0;
            if(ProductName.Text.Length==0||Quantity.Text.Length==0||Price.Text.Length==0)
            {
                DataStatus.Text = "Invalid Input";
                DataStatus.ForeColor = Color.Red;
                DataStatus.Visible = true;
            }
            else
            {
                DataStatus.Visible = false;
                try
                {
                    using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbcs"].ConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand("Select * from Products where ProductName=@pname");
                        cmd.Connection = connection;
                        cmd.Parameters.AddWithValue("pname", ProductName.Text);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        count = dt.Rows.Count;
                    }
                }
                catch (SqlException dataBaseException)
                {
                    Response.Write("<script>if(confirm('There was some problem loading the data, pls try again later'){window.location='ProductManipulation.aspx';})</script>");
                }
                catch(Exception exception)
                {
                    Response.Write("<script>if('Error try again later'){window.location='ProductManipulation.aspx';}</script>");
                }
                if (count > 0)
                {
                    DataStatus.Text = "This product name already exists";
                    DataStatus.ForeColor = Color.Red;
                    DataStatus.Visible = true;
                }
                else
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbcs"].ConnectionString))
                        {
                            SqlCommand cmd = new SqlCommand("Insert into Products values(@pname,@qty,@price)");
                            cmd.Connection = connection;
                            cmd.Parameters.AddWithValue("pname", ProductName.Text);
                            cmd.Parameters.AddWithValue("qty", Convert.ToInt32(Quantity.Text));
                            cmd.Parameters.AddWithValue("price", Convert.ToInt32(Price.Text));
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            count = dt.Rows.Count;
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
                    Session.Clear();
                    Response.Write("<script>if(confirm('Product Added')){window.location='ProductManipulation.aspx';}</script>");    
                }
            }
        }
    }
}
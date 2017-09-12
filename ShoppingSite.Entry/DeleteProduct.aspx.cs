using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace ShoppingSite.Entry
{
    public partial class DeleteProduct : System.Web.UI.Page
    {
        private readonly string _session = "Identified";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session[_session]!=null)
            {
                int count=0;
                string pid = Request.QueryString["pid"];
                using(SqlConnection connection=new SqlConnection(WebConfigurationManager.ConnectionStrings["dbcs"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("Select * from Products where ProductId=@pid");
                    cmd.Parameters.AddWithValue("pid", pid);
                    cmd.Connection = connection;
                    SqlDataAdapter dAdap = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    dAdap.Fill(ds);
                    count = ds.Tables[0].Rows.Count;
                }
                if (count != 0)
                {
                    using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbcs"].ConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand("Select * from OrderDetails where ProductId=@pid");
                        cmd.Parameters.AddWithValue("pid", pid);
                        cmd.Connection = connection;
                        SqlDataAdapter dAdap = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        dAdap.Fill(ds);
                        count = ds.Tables[0].Rows.Count;
                    }
                    if(count==0)
                    {
                        using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbcs"].ConnectionString))
                        {
                            SqlCommand cmd = new SqlCommand("Delete * from Products where ProductId=@pid");
                            cmd.Parameters.AddWithValue("pid", pid);
                            cmd.Connection = connection;
                            SqlDataAdapter dAdap = new SqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            dAdap.Fill(ds);
                            Response.Write("<script>confirm('The product has been deleted')</script>");
                            Session.Clear();
                            Response.Redirect("ProductManipulation.aspx");
                        }
                    }
                    else
                    {
                        Response.Write("<script>confirm('The product has been already sold!! It cannot be deleted!!')</script>");
                        Response.Redirect("ProductManipulation.aspx");
                    }
                }
                else
                {
                    Response.Write("<script>confirm('No such product exists!!')</script>");
                    Response.Redirect("ProductManipulation.aspx");
                }
            }
            else Response.Redirect("ProductManipulation.aspx");
        }
    }
}
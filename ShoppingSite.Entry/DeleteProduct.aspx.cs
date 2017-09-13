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
                count = performDbOperation("Select * from Products where ProductId=@pid", pid,"no");
                if (count != 0)
                {
                    count = performDbOperation("Select * from OrderDetails where ProductId=@pid", pid,"no");
                    if(count==0)
                    {
                        count = performDbOperation("Delete from Products where ProductId=@pid", pid,null);
                            Response.Write("<script>" +
                                "if(confirm('The product has been deleted'))" +
                                "{window.location='ProductManipulation.aspx';}" +
                                "</script>");
                            Session.Clear();
                    }
                    else Response.Write("<script>if(confirm('The product has been already sold!! It cannot be deleted!!')){window.location='ProductManipulation.aspx';}</script>");
                }
                else Response.Write("<script>if(confirm('No such product exists!!')){window.location='ProductManipulation.aspx';}</script>"); 
            }
            else Response.Redirect("ProductManipulation.aspx");
        }

        private int performDbOperation(string command,string parameter,string dontRead)
        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbcs"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(command);
                cmd.Parameters.AddWithValue("pid", parameter);
                cmd.Connection = connection;
                SqlDataAdapter dAdap = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                dAdap.Fill(ds);
                if(dontRead!=null)
                 count = ds.Tables[0].Rows.Count;
            }
            return count;
        }
    }
}
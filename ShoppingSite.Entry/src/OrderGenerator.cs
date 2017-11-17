using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using ShoppingSite.Core;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace ShoppingSite.Entry.src
{
    public class OrderGenerator
    {
        public static Order Generate(Dictionary<string, string> ProductIds, Dictionary<string, int> ProductPrice, Dictionary<string, int> CartItems, int CartAmount)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            string orderId = null;
            List<string> items = new List<string>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Insert into Orders OUTPUT inserted.OrderId values(@DateTime,@TotalAmount)";
                    cmd.Parameters.AddWithValue("DateTime", DateTime.UtcNow.AddHours(5.5).ToString());
                    cmd.Parameters.AddWithValue("TotalAmount", CartAmount.ToString());
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable returnedData = new DataTable();
                    da.Fill(returnedData);
                    orderId = (returnedData.Rows[0][0]).ToString();
                }
                foreach (KeyValuePair<string, int> cartItem in CartItems)
                {
                    items.Add(cartItem.Key);
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = connection;
                        cmd.CommandText = "Insert into OrderDetails values(@OrderId,@ProductId,@Quantity,@ProductPrice)";
                        cmd.Parameters.AddWithValue("OrderId", orderId);
                        cmd.Parameters.AddWithValue("ProductId", ProductIds[cartItem.Key]);
                        cmd.Parameters.AddWithValue("Quantity", cartItem.Value);
                        cmd.Parameters.AddWithValue("ProductPrice", ProductPrice[cartItem.Key]);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable returnedData = new DataTable();
                        da.Fill(returnedData);
                    }
                }
            }
            catch(Exception ex)
            {

            }
            Order orderPro = new Order(orderId, items, DateTime.UtcNow.AddHours(5.5), Convert.ToDouble(CartAmount), Guid.NewGuid().ToString());
            return orderPro;
        }
    }
}
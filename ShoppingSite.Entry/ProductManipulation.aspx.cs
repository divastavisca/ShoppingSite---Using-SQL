using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShoppingSite.Entry.src;
using System.Data.SqlClient;

namespace ShoppingSite.Entry
{
    public partial class ProductManipulation : System.Web.UI.Page
    {
        private readonly string _session = "Identified";
        private readonly string _inventoryManager = "IManager";
        private readonly string _inventory = "Inventory";
        private readonly string _inventoryMap = "InventoryMap";
        private readonly string _productPrice = "ProductPrice";
        private readonly string _productIds = "ProductId";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[_session] == null)
            {
                InventoryManagerGenerator generator = new InventoryManagerGenerator();
                Session[_session] = "ongoing";
                Session[_inventoryManager] = generator.InventoryManager;
                Session[_productIds] = generator.ItemsGenerator.ProductIds;
                Session[_inventory] = generator.Inventory;
                Session[_inventoryMap] = generator.InventoryMap;
                Session[_productPrice] = generator.ItemsGenerator.ItemPrice;
            }
            populateProducts();
        }

        private void populateProducts()
        {
            try
            {
                Dictionary<string, List<string>> inventoryMap = (Dictionary<string, List<string>>)Session[_inventoryMap];
                Dictionary<string, string> productMap = (Dictionary<string, string>)Session[_productIds];
                Dictionary<string, int> productPrices = (Dictionary<string, int>)Session[_productPrice];
                foreach (KeyValuePair<string, List<string>> pair in inventoryMap)
                {
                    TableCell pInfo = new TableCell();
                    TableCell pPrice = new TableCell();
                    TableCell pCount = new TableCell();
                    TableCell pEditAction = new TableCell();
                    TableCell pDeleteAction = new TableCell();
                    string productInfo = pair.Key;
                    int productCount = pair.Value.Count;
                    string productId = productMap[productInfo];
                    int productPrice = productPrices[productInfo];
                    pInfo.Text = productInfo;
                    pPrice.Text = productPrice.ToString();
                    pCount.Text = productCount.ToString();
                    LinkButton editButton = new LinkButton();
                    editButton.Text = "Edit";
                    editButton.PostBackUrl = "EditProduct.aspx?pid=" + productId;
                    pEditAction.Controls.Add(editButton);
                    LinkButton deleteButton = new LinkButton();
                    deleteButton.Text = "Delete";
                    deleteButton.PostBackUrl = "DeleteProduct.aspx?pid=" + productId;
                    deleteButton.OnClientClick = "return confirm('Are you sure you want to delete this item?')";
                    pDeleteAction.Controls.Add(deleteButton);
                    TableRow row = new TableRow();
                    row.Cells.Add(pInfo);
                    row.Cells.Add(pPrice);
                    row.Cells.Add(pCount);
                    row.Cells.Add(pEditAction);
                    row.Cells.Add(pDeleteAction);
                    TableProducts.Rows.Add(row);
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSite.Core
{
    public class ShoppingCart
    {
        private List<IItem> _cartItems;

        public bool RemoveItem(string itemInfo)
        {
            foreach(IItem item in _cartItems)
                if(item.GetItemInfo()==itemInfo)
                {
                    _cartItems.Remove(item);
                    return true;
                }
            return false;
        }

        public List<IItem> GetItems()
        {
            return _cartItems;
        }

        public void AddItem(IItem item)
        {
            _cartItems.Add(item);
        }

        public ShoppingCart()
        {
            _cartItems = new List<IItem>();
        }
    }
}

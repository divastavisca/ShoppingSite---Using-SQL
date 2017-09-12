using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSite.Core
{
    public class Inventory
    {
        private List<IItem> _itemCollection;

        public void AddItem(IItem item)
        {
            _itemCollection.Add(item);
        }

        public bool IsAvailable(string itemInfo)
        {
            foreach (IItem item in _itemCollection)
            {
                if (item.GetItemInfo() == itemInfo)
                {
                    return true;
                }
            }
            return false;
        }

        public IItem RemoveItem(string itemId)
        {
            foreach(IItem item in _itemCollection)
            {
                if(item.GetItemId()==itemId)
                {
                    _itemCollection.Remove(item);
                    return item;
                }
            }
            return null;
        }

        public Inventory(List<IItem> itemCollection)
        {
            _itemCollection = itemCollection;
        }
    }
}

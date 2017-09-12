using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSite.Core
{
    public class InventoryManager
    {
        private Inventory _inventory;

        /// <summary>
        /// Maps inventory info to a list of inventory item ID's list, Item Info -> List of Items
        /// </summary>
        private Dictionary<string, List<string>> _inventoryMap;


        /// <summary>
        /// Maintains log of items to dispatchment details, ID -> Disptachment details
        /// </summary>
        private Dictionary<string, Dispachment> _inventoryLog;

        /// <summary>
        /// Gets the count of a specific item 
        /// </summary>
        /// <param name="itemInfo"></param>
        /// <returns></returns>
        public int GetItemCount(string itemInfo)
        {
            if (IsAvailable(itemInfo))
                return _inventoryMap[itemInfo].Count;
            else return 0;
        }

        /// <summary>
        /// Gets availability of an item
        /// </summary>
        /// <param name="itemInfo"></param>
        /// <returns></returns>
        public bool IsAvailable(string itemInfo)
        {
            return _inventoryMap[itemInfo] != null && _inventoryMap[itemInfo].Count > 0;
        }

        /// <summary>
        /// Store a new inventory item
        /// </summary>
        /// <param name="newItem"></param>
        public void StoreItem(IItem newItem)
        {
            if(_inventoryMap[newItem.GetItemInfo()]==null)
            {
                _inventoryMap.Add
               (
                    newItem.GetItemInfo(), 
                    new List<string>()
                    {
                        { newItem.GetItemId() }
                    }
               );
            }
            else
            {
                _inventoryMap[newItem.GetItemInfo()].Add(newItem.GetItemId());
            }
        }

        /// <summary>
        /// Get an item from the inventory
        /// </summary>
        /// <param name="itemInfo"></param>
        /// <returns></returns>
        public IItem GetInventory(string itemInfo)
        {
            return dispatch(itemInfo);
        }

        private IItem dispatch(string itemInfo)
        {
            if(IsAvailable(itemInfo))
            {
                string dispachableItemId = _inventoryMap[itemInfo][0];
                _inventoryMap[itemInfo].RemoveAt(0);
                Dispachment dispatchment = new Dispachment
                    (
                        dispachableItemId,
                        DateTime.Now
                    );
                _inventoryLog.Add(dispachableItemId, dispatchment);
                return _inventory.RemoveItem(dispachableItemId);
            }
            return null;
        }

        public InventoryManager(Inventory inventory,Dictionary<string,List<string>> inventoryMap,Dictionary<string,Dispachment> inventoryLog)
        {
            _inventory = inventory;
            _inventoryMap = inventoryMap;
            _inventoryLog = inventoryLog;
        }
    }
}

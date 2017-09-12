﻿using ShoppingSite.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ShoppingSite.Entry.src
{
    public class InventoryManagerGenerator
    {
        public InventoryManager InventoryManager { get; private set; }
        public Inventory Inventory { get; private set; }
        public Dictionary<string, List<string>> InventoryMap { get; private set; }
        public Dictionary<string, int> ProductMap { get; private set; }

        public ItemsGenerator ItemsGenerator { get; private set; }
        public InventoryManagerGenerator()
        {
            InventoryGenerator inventory = new InventoryGenerator();
            ItemsGenerator = inventory.ItemsGenerator;
            ProductMap = inventory.ItemsGenerator.ProductMap;
            Inventory = inventory.Inventory;
            InventoryMap = inventory.ItemsGenerator.ItemMap;
            Dictionary<string, Dispachment> inventoryLog = new Dictionary<string, Dispachment>();
            InventoryManager= new InventoryManager(Inventory, inventory.ItemsGenerator.ItemMap, inventoryLog);
        }
        
        private void PopulateStatically()
        {
            int i = 1;
            ProductMap = new Dictionary<string, int>(); 
            foreach (string key in InventoryMap.Keys)
            {
                ProductMap.Add(key, i++);
            }
        }
    }
}
using ShoppingSite.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite.Entry.src
{
    public class InventoryGenerator
    {
        public Inventory Inventory { get; }
        public ItemsGenerator ItemsGenerator { get; }
        public InventoryGenerator()
        {
            ItemsGenerator = new ItemsGenerator();
            Inventory = new Inventory(ItemsGenerator.Items);
        }
    }
}
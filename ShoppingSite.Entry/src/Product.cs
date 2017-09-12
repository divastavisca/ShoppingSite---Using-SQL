using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingSite.Core;

namespace ShoppingSite.Entry.src
{
    public class Product : Item
    {
        public Product(string id, string info, double price) : base(id, price)
        {
            Info = info;
        }
    }
}
using ShoppingSite.Core;

namespace ShoppingSite.Entry.src
{
    public class Mobile : Item, IItem
    {
        public Mobile(string id, string info, double price): base(id,price)
       {
            Info = info;
       }
    }
}
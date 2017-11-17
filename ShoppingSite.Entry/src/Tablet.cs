using ShoppingSite.Core;

namespace ShoppingSite.Entry.src
{
    public class Tablet : Item, IItem
    {
        public Tablet(string id, string info,double price) : base(id,price)
        {
            Info = info;
        }
    }
}
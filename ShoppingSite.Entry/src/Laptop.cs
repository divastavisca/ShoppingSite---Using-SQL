using ShoppingSite.Core;

namespace ShoppingSite.Entry.src
{
    public class Laptop : Item, IItem
    {
        public Laptop(string id, string info,double price) : base(id,price)
        {
            Info = info;
        }
    }
}
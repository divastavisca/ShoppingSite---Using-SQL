using ShoppingSite.Core;

namespace ShoppingSite.Entry.src
{
    public class WashingMachine : Item, IItem
    {
        public WashingMachine(string id, string info,double price) : base(id,price)
        {
            Info = info;
        }
    }
}
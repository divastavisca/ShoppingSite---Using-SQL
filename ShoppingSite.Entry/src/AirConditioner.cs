using ShoppingSite.Core;

namespace ShoppingSite.Entry.src
{
    public class AirConditioner : Item, IItem
    {
        public AirConditioner(string id, string info,double price) : base(id,price)
        {
            Info = info;
        }
    }
}
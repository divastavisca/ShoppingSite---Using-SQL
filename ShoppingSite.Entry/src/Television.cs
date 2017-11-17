using ShoppingSite.Core;

namespace ShoppingSite.Entry.src
{
    public class Television : Item, IItem
    {
        public Television(string id, string info,double price) : base(id,price)
        {
            Info = info;
        }
    }
}
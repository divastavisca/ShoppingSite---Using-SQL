using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSite.Core
{
    public class Dispachment
    {
        public string ItemId { get; private set; }
        public DateTime DispachTime { get; private set; }

        public Dispachment(string itemId,DateTime dispatchTime)
        {
            ItemId = itemId;
            DispachTime = dispatchTime;
        }
    }
}

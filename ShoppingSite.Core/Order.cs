using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSite.Core
{
    public class Order
    {
        public string OrderId { get; private set; }

        public List<string> Items { get; private set; }

        public DateTime OrderDate { get; private set; }

        public double OrderAmount { get; private set; }

        public string CustomerId { get; private set; }

        public Order(string orderId,List<string> orderItems,DateTime orderTime,double orderAmount,string customerId)
        {
            OrderId = orderId;
            Items = orderItems;
            OrderDate = orderTime;
            OrderAmount = orderAmount;
            CustomerId = customerId;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSite.Core
{
    public class Customer
    {
        public string CustomerId { get; private set; }

        public Name CustomerName { get; private set; }

        public List<Address> AddressList { get; private set; }

        public string ContactDetails { get; private set; }

        public Customer(string customerId,Name customerName, List<Address> addressList,string customerContact)
        {
            CustomerId = customerId;
            CustomerName = customerName;
            AddressList = addressList;
            ContactDetails = customerContact;
        }
    }
}

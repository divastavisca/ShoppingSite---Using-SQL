using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSite.Core
{
    public class Address
    {
        public string PlotNo { get; private set; }
        public string Locality { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string PinCode { get; private set; }
        public string LandMark { get; private set; }

        public static bool IsPinCodeValid(string pinCode)
        {
            int value;
            if(Int32.TryParse(pinCode,out value))
            {
                if (pinCode.Length == 6)
                    return true;
                return false;
            }
            return false;
        }

        public Address(string plotNo,string locality,string street,string city,string state,string country,string pinCode,string landMark)
        {
            PlotNo = plotNo;
            Locality = locality;
            Street = street;
            City = city;
            State = state;
            Country = country;
            PinCode = pinCode;
            LandMark = landMark;
        }
    }
}

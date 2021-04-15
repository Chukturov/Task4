using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    public class Order
    {
        public string fullName { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }


        public Order(string fullName, string address, string phoneNumber)
        {
            this.fullName = fullName;
            this.address = address;
            this.phoneNumber = phoneNumber;
        }

        public void outInf()
        {
            Console.WriteLine(@"{0} {1} {2}", fullName, address, phoneNumber);
        }


    }

}

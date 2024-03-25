using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reports
{
    public class Orders
    {
        public int orderID {  get; set; }
        public string contactName {  get; set; }
        public string customerID { get; set; }
        public string postalCode {  get; set; }
        public string address {  get; set; }
        public string city {  get; set; }
        public string phone {  get; set; }

        public Orders() { }

        public Orders(int orderId, string contactName, string customerID, string postalCode, string address, string city, string phone)
        {
            this.orderID = orderId;
            this.contactName = contactName;
            this.customerID = customerID;
            this.postalCode = postalCode;
            this.address = address;
            this.city = city;
            this.phone = phone;
        }
    }
}

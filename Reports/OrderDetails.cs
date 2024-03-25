using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reports
{
    public class OrderDetails
    {
        public int orderID {  get; set; }
        public string productName { get; set; }
        public int quantity { get; set; }
        public decimal discount { get; set; }
        public decimal unitPrice { get; set; }
        public decimal total 
        {
            get
            {
                return quantity * unitPrice - quantity * unitPrice * discount;
            }
        }

    }
}

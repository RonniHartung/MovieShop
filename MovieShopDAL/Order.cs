using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieShopDAL
{
    public class Order
    {
        public int OrderId { get; set; }
        public int customerId { get; set; }
        public DateTime orderDate { get; set; }


    }
}
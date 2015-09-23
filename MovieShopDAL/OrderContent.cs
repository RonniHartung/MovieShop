using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieShopDAL
{
    public class OrderContent
    {
        public int OrderContentID { get; set; }
        public int orderID { get; set; }
        public int movieID { get; set; }
    }
}
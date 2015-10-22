using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieShopDAL
{
    public class Order
    {
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? OrderDate { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual List<OrderContent> OrderContents { get; set; }
    }
}
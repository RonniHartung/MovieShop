using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieShopDAL
{
    public class OrderContent
    {
        [Key]
        [Column(Order = 10)]
        public int ContentId { get; set; }
        [Key]
        [Column(Order = 20)]
        public int OrderId { get; set; }
        public int MovieId { get; set; }

        public virtual Movie Movies { get; set; }
        public virtual Order Orders { get; set; }
    }
}
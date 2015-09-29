using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace MovieShopDAL
{
    public class Movie
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price {get; set; }
        public string ImageUrl { get; set; }
        public string TrailerUrl { get; set; }

        public int CategoryId { get; set; }
       
        public virtual Category Category { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace MovieShopDAL
{
    public class Movie
    {

        public int Id { get; set; }
        public string Title { get; set; }

        //[Range(typeof(decimal), "0,00", "9999,99")]
        //[DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public decimal Price {get; set; }

        public string ImageUrl { get; set; }
        public string TrailerUrl { get; set; }

        public int CategoryId { get; set; }
       
        public virtual Category Category { get; set; }
    }
}
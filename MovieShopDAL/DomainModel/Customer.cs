using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieShopDAL
{
    public class Customer
    {
        
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Adresse { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
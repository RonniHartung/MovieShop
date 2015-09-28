using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieShopDAL
{
    public class DALFacade
    {
        private IRepository<Customer> customerRepository;

        public IRepository<Customer> CustomerRepository
        {
            get
            {
                return customerRepository == null ? customerRepository =
                    new CustomerRepository() : customerRepository;
            }

        }
    }
}
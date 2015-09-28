using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace MovieShopDAL
{
    public class CustomerRepository : IRepository<Customer>
    {
        public void Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {

            using (MovieStoreDbContext db = new MovieStoreDbContext())
            {
                return db.Customers.ToList();
            }
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
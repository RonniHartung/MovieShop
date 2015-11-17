using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace MovieShopDAL
{
    internal class CustomerRepository : IRepository<Customer>
    {


        public void Add(Customer entity)
        {
            using (MovieStoreDbContext db = new MovieStoreDbContext())
            {
                db.Customers.Add(entity);
                db.SaveChanges();
            }
        }

        public void Edit(Customer entity)
        {
            using (MovieStoreDbContext db = new MovieStoreDbContext())
            {
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public Customer Get(int id)
        {
            using (MovieStoreDbContext db = new MovieStoreDbContext())
            {
                return db.Customers.Include(o => o.Orders).Include("Orders.OrderContents").Include("Orders.OrderContents.Movie").SingleOrDefault(x=> x.Id == id);
            }
        }


        public IEnumerable<Customer> Get()
        {

            using (MovieStoreDbContext db = new MovieStoreDbContext())
            {
                return db.Customers.ToList();
            }
        }

        public void Remove(int id)
        {
            using (MovieStoreDbContext db = new MovieStoreDbContext())
            {
                var customer = db.Customers.Find(id);
                db.Customers.Remove(customer);
                db.SaveChanges();
            }
        }

        public bool Update(Customer entity)
        {
            throw new NotImplementedException();
        }

        Customer IRepository<Customer>.Add(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
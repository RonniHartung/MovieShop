﻿using System;
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
                return db.Customers.SingleOrDefault();
            }
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
            using (MovieStoreDbContext db = new MovieStoreDbContext())
            {
                var customer = this.Get(id);
                db.Customers.Remove(customer);
                db.SaveChanges();
            }
        }
    }
}
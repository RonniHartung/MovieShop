using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace MovieShopDAL
{
    internal class OrderRepository : IRepository<Order>
    {
        public void Add(Order entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Order entity)
        {
            throw new NotImplementedException();
        }

        public Order Get(int id)
        {
            using (MovieStoreDbContext db = new MovieStoreDbContext())
            {
                return db.Orders.Include(p => p.OrderContents).SingleOrDefault();
            }
        }

        public IEnumerable<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
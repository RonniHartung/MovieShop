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
            using (MovieStoreDbContext db = new MovieStoreDbContext())
            {
                db.Orders.Add(entity);
                db.SaveChanges();
            }
        }

        public void Edit(Order entity)
        {
            throw new NotImplementedException();
        }

        public Order Get(int id)
        {
            using (MovieStoreDbContext db = new MovieStoreDbContext())
            {
                return db.Orders.Include(p => p.OrderContents).Distinct().SingleOrDefault();
            }
        }



        public IEnumerable<Order> Get()
        {
            using (MovieStoreDbContext db = new MovieStoreDbContext())
            {
                return db.Orders.ToList();
            }
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

    }
}
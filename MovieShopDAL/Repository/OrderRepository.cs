using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace MovieShopDAL
{
    internal class OrderRepository : IRepository<Order>
    {
        DALFacade facade = new DALFacade();
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
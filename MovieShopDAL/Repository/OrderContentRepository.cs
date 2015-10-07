using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MovieShopDAL
{
    internal class OrderContentRepository : IRepository<OrderContent>
    {
        public void Add(OrderContent entity)
        {
            using (MovieStoreDbContext db = new MovieStoreDbContext())
            {
                db.OrderContents.Add(entity);
                db.SaveChanges();
            }
        }

        public void Edit(OrderContent entity)
        {
            using (MovieStoreDbContext db = new MovieStoreDbContext())
            {
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public OrderContent Get(int id)
        {
            using (MovieStoreDbContext db = new MovieStoreDbContext())
            {
                return db.OrderContents.Find(id);
            }
        }

        public IEnumerable<OrderContent> GetAll()
        {
            using (MovieStoreDbContext db = new MovieStoreDbContext())
            {
                return db.OrderContents.ToList();
            }
        }

        public void Remove(int id)
        {
            using (MovieStoreDbContext db = new MovieStoreDbContext())
            {
                var oc = db.OrderContents.Find(id);
                db.OrderContents.Remove(oc);
                db.SaveChanges();
            }
        }
    }
}
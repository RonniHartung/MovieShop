using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MovieShopDAL
{
    internal class CategoryRepository : IRepository<Category>
    {
        void IRepository<Category>.Add(Category entity)
        {
            using (MovieStoreDbContext db = new MovieStoreDbContext())
            {
                db.Categories.Add(entity);
                db.SaveChanges();
            }
        }

        void IRepository<Category>.Edit(Category entity)
        {
            using (MovieStoreDbContext db = new MovieStoreDbContext())
            {
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        Category IRepository<Category>.Get(int id)
        {
            using (MovieStoreDbContext db = new MovieStoreDbContext())
            {
                return db.Categories.Find(id);
            }
        }


        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            using (MovieStoreDbContext db = new MovieStoreDbContext())
            {
                return db.Categories.ToList();
            }
        }

        void IRepository<Category>.Remove(int id)
        {
            using (MovieStoreDbContext db = new MovieStoreDbContext())
            {
                var categories = db.Categories.Find(id);
                db.Categories.Remove(categories);
                db.SaveChanges();
            }
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MovieShopDAL
{
    internal class CategoryRepository : IRepository<Category>
    {

        public void Add(Category entity)
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

        IEnumerable<Category> IRepository<Category>.Get()
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

        public bool Update(Category entity)
        {
            throw new NotImplementedException();
        }

        Category IRepository<Category>.Add(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
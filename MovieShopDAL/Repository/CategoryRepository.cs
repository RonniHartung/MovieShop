using System;
using System.Collections.Generic;

namespace MovieShopDAL
{
    internal class CategoryRepository : IRepository<Category>
    {
        void IRepository<Category>.Add(Category entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<Category>.Edit(Category entity)
        {
            throw new NotImplementedException();
        }

        Category IRepository<Category>.Get(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Category> IRepository<Category>.GetAll()
        {
            throw new NotImplementedException();
        }

        void IRepository<Category>.Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
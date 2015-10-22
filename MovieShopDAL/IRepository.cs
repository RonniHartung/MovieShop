﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDAL
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get();
        T Get(int id);
        void Add(T entity);
        void Edit(T entity);
        void Remove(int id);
    }
}

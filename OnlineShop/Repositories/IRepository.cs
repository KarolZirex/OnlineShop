﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnlineShop.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        TEntity Get (int id);
        IEnumerable<TEntity> GetAll(); 
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>>predicate);
    }
}

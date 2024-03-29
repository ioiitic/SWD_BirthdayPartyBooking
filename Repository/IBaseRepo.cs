﻿using Microsoft.EntityFrameworkCore;
using Repository.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IBaseRepo<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(string[] children);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter, string[] children);
        T GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
    }
}

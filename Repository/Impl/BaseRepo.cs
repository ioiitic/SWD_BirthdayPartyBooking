using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repository.Impl
{
    public abstract class BaseRepo<T> : IBaseRepo<T> where T : class
    {
        protected BirthdayPartyBookingContext _context;

        public BaseRepo(BirthdayPartyBookingContext context)
        {
            _context = context; 
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public IEnumerable<T> GetAll(string[] children)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (string entity in children)
            {
                query = query.Include(entity);

            }
            return query.ToList();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = _context.Set<T>();
            return query.Where(filter).ToList();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter, string[] children)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (string entity in children)
            {
                query = query.Include(entity);

            }
            return query.Where(filter).ToList();
        }

        public T GetById(object id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Insert(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            _context.Set<T>().Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(object id)
        {
            T existing = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(existing);
        }
    }
}

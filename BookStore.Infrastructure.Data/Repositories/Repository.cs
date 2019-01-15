using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BookStore.Core.Entities;
using BookStore.Core.Interfaces;
using BookStore.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        protected readonly ApplicationContext _dbContext;

        public Repository()
        {
            _dbContext = new ApplicationContext();
        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public IEnumerable<T> List()
        {
            return _dbContext.Set<T>().AsEnumerable();
        }

        public IEnumerable<T> List(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>()
               .Where(predicate)
               .AsEnumerable();
        }

        public void Insert(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Edit(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();   
        }        
    }
}

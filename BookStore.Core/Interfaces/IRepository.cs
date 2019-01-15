using BookStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BookStore.Core.Interfaces
{
    public interface IRepository<T> where T : EntityBase
    {
        //Select
        T GetById(int id);
        IEnumerable<T> List();
        IEnumerable<T> List(Expression<Func<T, bool>> predicate);

        //Add
        void Insert(T entity);
        
        //Del
        void Delete(T entity);

        //Update
        void Edit(T entity);        
    }
}

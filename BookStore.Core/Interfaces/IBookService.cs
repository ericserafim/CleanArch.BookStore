using System.Collections.Generic;
using BookStore.Core.Entities;

namespace BookStore.Core.Interfaces
{
    public interface IBookService
    {
        //Select
        Book Get(int Id);
        List<Book> GetAll();
       // List<Book> Find(Expression<Func<Book, bool>> predicate);
        List<Book> GetTopSellingBooks(int count);

        //Add
        void Add(Book book);
        void AddRange(List<Book> entities);

        //Update
        void Update(Book book);

        //Del
        void Remove(Book book);
        void RemoveRange(List<Book> entities);
    }
}

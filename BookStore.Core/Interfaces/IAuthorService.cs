using System.Collections.Generic;
using BookStore.Core.Entities;

namespace BookStore.Core.Interfaces
{
    public interface IAuthorService
    {
        //Select
        Author Get(int Id);
        List<Author> GetAll();
       // List<Author> Find(Expression<Func<Author, bool>> predicate);
        List<Author> GetTopSellingAuthors(int count);

        //Add
        void Add(Author Author);
        void AddRange(List<Author> entities);

        //Update
        void Update(Author Author);

        //Del
        void Remove(Author Author);
        void RemoveRange(List<Author> entities);
    }
}

using BookStore.Core.Interfaces;
using BookStore.Core.Entities;

namespace BookStore.Infrastructure.Data.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
    }    
}

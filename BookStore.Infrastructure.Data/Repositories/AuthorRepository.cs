using BookStore.Core.Entities;
using BookStore.Core.Interfaces;

namespace BookStore.Infrastructure.Data.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {        
    }
}

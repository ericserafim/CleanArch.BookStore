using BookStore.Core.Entities;
using BookStore.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Core.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepo;
        private readonly IBookRepository _bookRepo;

        public AuthorService(IAuthorRepository AuthorRepository, IBookRepository bookRepository)
        {
            _authorRepo = AuthorRepository;
            _bookRepo = bookRepository;
        }

        public void Add(Author Author)
        {
            _authorRepo.Insert(Author);
        }

        public void AddRange(List<Author> entities)
        {
            foreach (var b in entities)
            {
                Add(b);
            }
        }

        public Author Get(int id)
        {
            var author = _authorRepo.GetById(id);

            if (author != null)
                author.Books.CopyTo(_bookRepo.List(b => b.Author.Id == id).ToArray(), 0);

            return author;
        }

        public List<Author> GetAll()
        {
            return _authorRepo.List().ToList();
        }

        public List<Author> GetTopSellingAuthors(int count)
        {
            return _authorRepo
                .List()
                .Take(count)
                .ToList();
        }

        public void Update(Author Author)
        {
            Author _Author = Get(Author.Id);
            _Author.Name = Author.Name;

            _authorRepo.Edit(_Author);
        }

        public void Remove(Author Author)
        {
            _authorRepo.Delete(Author);
        }

        public void RemoveRange(List<Author> entities)
        {
            foreach (var b in entities)
            {
                Remove(b);
            }
        }

    }
}

using BookStore.Core.Interfaces;
using BookStore.Core.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BookStore.Core.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepo;
        private readonly IAuthorRepository _authorRepo;

        public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            _bookRepo = bookRepository;
            _authorRepo = authorRepository;
        }

        public void Add(Book book)
        {
            if (book.Author == null || book.Author.Id <= 0)
                throw new InvalidDataException("To create a Book you need a Author");
            if (_authorRepo.GetById(book.Author.Id) == null)
                throw new InvalidDataException("Author not found");

            _bookRepo.Insert(book);
        }

        public void AddRange(List<Book> entities)
        {
            foreach (var b in entities)
            {
                Add(b);
            }
        }

        public Book Get(int id)
        {
            Book _book = _bookRepo.GetById(id);
            _book.Author = _authorRepo.GetById(_book.Author.Id);

            return _book; 
        }

        public List<Book> GetAll()
        {
            return _bookRepo.List().ToList();
        }

        public List<Book> GetTopSellingBooks(int count)
        {
            return _bookRepo
                .List()                
                .OrderBy(b => b.NumPages) //TODO Change it later to use sales amount
                .Take(count)
                .ToList();
        }

        public void Update(Book book)
        {
            Book _book = Get(book.Id);
            _book.Title = book.Title;
            _book.NumPages = book.NumPages;

            _bookRepo.Edit(_book);
        }

        public void Remove(Book book)
        {
            _bookRepo.Delete(book);
        }

        public void RemoveRange(List<Book> entities)
        {
            foreach (var b in entities)
            {
                Remove(b);
            }
        }

    }
}

using BookStore.Core.Interfaces;
using BookStore.Core.Entities;
using System;
using System.Linq;

namespace BookStore.UI.ConsoleApp
{
    public class StartUp : IStartUp
    {        
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;

        public StartUp(IBookService bookService, IAuthorService authorService)
        {            
            _bookService = bookService;
            _authorService = authorService;
        }

        public void Start()
        {
            #region Author
            _authorService.Add(new Author() {Name = "Author 1"});

            var author = _authorService.Get(1);
            Console.WriteLine($"{author.Id} - {author.Name}");
            foreach (var b in author.Books)
            {
                PrintBook(b);
            }
            #endregion

            #region Book                        
            AddRangeBooks();
            ListBooksAll();
            DeleteLastBook();
            ListBooksAll();            
            #endregion

            Console.ReadKey();
        }

        private void AddRangeBooks()
        {
            _bookService.Add(new Book()
            {
                Title = "Clean Architecture",
                NumPages = 350,

                Author = new Author()
                {
                    Name = "Teste",
                    Origin = "BR"
                }
            });

            _bookService.Add(new Book()
            {
                Title = "The Lords Of The Rings",
                NumPages = 1900,

                Author = new Author()
                {
                    Name = "Teste",
                    Origin = "BR"
                }
            });

            _bookService.Add(new Book()
            {
                Title = "The Subtle Art of Not Giving a Fuck",
                NumPages = 142,


                Author = new Author()
                {
                    Name = "Teste",
                    Origin = "BR"
                }
            });
        }

        private void ListBooksAll()
        {
            StringReplicate('-', 50);
            Console.WriteLine("Book List");
            StringReplicate('-', 50);

            var books = _bookService.GetAll();
            foreach (var book in books)
            {
                PrintBook(book);
            }

            Console.WriteLine("");
            Console.WriteLine("");
        }

        private static void PrintBook(Book book)
        {
            Console.WriteLine($"Id: {book.Id} - Title: {book.Title} - Pages: {book.NumPages}");
        }

        private void DeleteLastBook()
        {
            _bookService.Remove(_bookService.GetAll().LastOrDefault());
        }

        private static void StringReplicate(char chr, int count)
        {
            Console.WriteLine(new String(chr, count));
        }
    }
}

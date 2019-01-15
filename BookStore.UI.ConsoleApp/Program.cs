using BookStore.Core.Interfaces;
using BookStore.Core.Services;
using BookStore.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.UI.ConsoleApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IStartUp, StartUp>();

            var serviceProvider = services.BuildServiceProvider();
            var startUp = serviceProvider.GetRequiredService<IStartUp>();
            startUp.Start();
        }

    }
}

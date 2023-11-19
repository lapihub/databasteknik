using BookList_Project.Contexts;
using BookList_Project.Menus;
using BookList_Project.Repos;
using BookList_Project.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookList_Project
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddDbContext<DataContext>(options => options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Nackademin\Databasteknik\Projekt\Final\BookList_Project\Contexts\Db_Project.mdf;Integrated Security=True;Connect Timeout=30"));

            services.AddScoped<BookRepo>();
            services.AddScoped<AuthorRepo>();
            services.AddScoped<GenreRepo>();
            services.AddScoped<PublisherRepo>();
            services.AddScoped<BookRatingRepo>();

            services.AddScoped<BookService>();
            services.AddScoped<BookDetailService>();
            services.AddScoped<BookRatingService>();

            services.AddScoped<BookMenu>();
            services.AddScoped<MainMenu>();
            services.AddScoped<BookDetailMenu>();
            services.AddScoped<BookRatingMenu>();

            var sp = services.BuildServiceProvider();
            var mainMenu = sp.GetRequiredService<MainMenu>();
            await mainMenu.StartAsync();
        }
    }
}
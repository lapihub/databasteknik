using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Test3_BookRating_Project.Context;
using Test3_BookRating_Project.Menus;
using Test3_BookRating_Project.Repositories;
using Test3_BookRating_Project.Services;

namespace Test2_Database_Library
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddDbContext<DataContext>(options => options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Nackademin\Databasteknik\Projekt\Test3_BookRating_Project\Test3_BookRating_Project\Context\Bookrating_db.mdf;Integrated Security=True;Connect Timeout=30"));

            services.AddScoped<BookRepo>();
            services.AddScoped<AuthorRepo>();
            services.AddScoped<GenreRepo>();
            services.AddScoped<PublisherRepo>();
            services.AddScoped<BookGenreRepo>();
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
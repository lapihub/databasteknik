using BookList_Project.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookList_Project.Contexts;

internal class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<AuthorEntity> Authors { get; set; }
    public DbSet<BookEntity> Books { get; set; }
    public DbSet<BookRatingEntity> BookRatings { get; set; }
    public DbSet<GenreEntity> Genres { get; set; }
    public DbSet<PublisherEntity> Publishers { get; set; }
}

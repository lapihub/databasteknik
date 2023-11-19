using Microsoft.EntityFrameworkCore;
using Test2_Database_Library.Entities;

namespace Test2_Database_Library.Context;

internal class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<AuthorEntity> Authors { get; set; }
    public DbSet<BookEntity> Books { get; set; }
    public DbSet<BookGenreEntity> BookGenres { get; set; }
    public DbSet<BorrowedBookEntity> BorrowedBooks { get; set; }
    public DbSet<GenreEntity> Genres { get; set; }
    public DbSet<PublisherEntity> Publishers { get; set; }
    public DbSet<UserEntity> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookGenreEntity>().HasKey(x => new {x.GenreId, x.BookId});
        
    }
}

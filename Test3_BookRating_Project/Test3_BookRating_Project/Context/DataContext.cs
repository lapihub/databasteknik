using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using Test3_BookRating_Project.Entities;

namespace Test3_BookRating_Project.Context;

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookRatingEntity>()
            .HasOne(x => x.Book)
            .WithMany(x => x.Ratings)
            .HasForeignKey(x => x.BookId)
            .HasConstraintName("FK_BookRatings_Books");           

        base.OnModelCreating(modelBuilder);
    }

}
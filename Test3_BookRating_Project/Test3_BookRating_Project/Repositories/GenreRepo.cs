using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Test3_BookRating_Project.Context;
using Test3_BookRating_Project.Entities;

namespace Test3_BookRating_Project.Repositories;

internal class GenreRepo : Repo<GenreEntity>
{
    private readonly DataContext _context;
    public GenreRepo(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BookEntity>> GetBooksByGenreAsync(string name)
    {
        try
        {
            var books = await _context.Books
                .Where(x => x.Genre.Name == name)
                .ToListAsync();
            return books;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return Enumerable.Empty<BookEntity>();
        }
    }
}

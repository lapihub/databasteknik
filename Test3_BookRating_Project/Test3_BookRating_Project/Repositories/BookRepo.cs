using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;
using Test3_BookRating_Project.Context;
using Test3_BookRating_Project.Entities;

namespace Test3_BookRating_Project.Repositories;

internal class BookRepo : Repo<BookEntity>
{
    private readonly DataContext _context;
    public BookRepo(DataContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<BookEntity>> GetAllAsync()
    {
        try
        {
            var books = await _context.Books.
            Include(x => x.Author).
            Include(x => x.Publisher).
            Include(x => x.Genre).
            ThenInclude(x => x.BookGenres).
            ToListAsync();
            return books;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public override async Task<BookEntity> GetAsync(Expression<Func<BookEntity, bool>> expression)
    {
        try
        {
            var book = await _context.Books
                .Include(x => x.Author)
                .Include(x => x.Publisher)
                .Include(x => x.Genre)
                .ThenInclude(x => x.BookGenres)
                .FirstOrDefaultAsync(expression);
            return book ?? null!;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }
}

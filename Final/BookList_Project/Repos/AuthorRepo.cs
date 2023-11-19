using BookList_Project.Contexts;
using BookList_Project.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BookList_Project.Repos;

internal class AuthorRepo : Repo<AuthorEntity>
{
    private readonly DataContext _context;
    public AuthorRepo(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BookEntity>> GetBooksByAuthorAsync(string firstName, string lastName)
    {
        try
        {
            var books = await _context.Books
                .Where(x => x.Author.FirstName == firstName && x.Author.LastName == lastName)
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

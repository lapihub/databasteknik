using BookList_Project.Contexts;
using BookList_Project.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BookList_Project.Repos;

internal class PublisherRepo : Repo<PublisherEntity>
{
    private readonly DataContext _context;
    public PublisherRepo(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BookEntity>> GetBooksByPublisherAsync(string name)
    {
        try
        {
            var books = await _context.Books
                .Where(x => x.Publisher.Name == name)
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
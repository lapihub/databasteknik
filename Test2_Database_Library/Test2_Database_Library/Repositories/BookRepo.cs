using Test2_Database_Library.Context;
using Test2_Database_Library.Entities;

namespace Test2_Database_Library.Repositories;

internal class BookRepo : Repo<BookEntity>
{
    private readonly DataContext _context;
    public BookRepo(DataContext context) : base(context)
    {
        _context = context;
    }
}

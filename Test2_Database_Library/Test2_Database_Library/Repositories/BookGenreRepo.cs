using Test2_Database_Library.Context;
using Test2_Database_Library.Entities;

namespace Test2_Database_Library.Repositories;

internal class BookGenreRepo : Repo<BookGenreEntity>
{
    private readonly DataContext _context;
    public BookGenreRepo(DataContext context) : base(context)
    {
        _context = context;
    }
}

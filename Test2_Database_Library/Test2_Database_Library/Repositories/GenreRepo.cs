using Test2_Database_Library.Context;
using Test2_Database_Library.Entities;

namespace Test2_Database_Library.Repositories;

internal class GenreRepo : Repo<GenreEntity>
{
    private readonly DataContext _context;
    public GenreRepo(DataContext context) : base(context)
    {
        _context = context;
    }
}

using Test2_Database_Library.Context;
using Test2_Database_Library.Entities;

namespace Test2_Database_Library.Repositories;

internal class AuthorRepo : Repo<AuthorEntity>
{
    private readonly DataContext _context;
    public AuthorRepo(DataContext context) : base(context)
    {
        _context = context;
    }
}

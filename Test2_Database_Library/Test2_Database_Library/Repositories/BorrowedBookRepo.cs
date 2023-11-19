using Test2_Database_Library.Context;
using Test2_Database_Library.Entities;

namespace Test2_Database_Library.Repositories;

internal class BorrowedBookRepo : Repo<BorrowedBookEntity>
{
    private readonly DataContext _context;
    public BorrowedBookRepo(DataContext context) : base(context)
    {
        _context = context;
    }
}

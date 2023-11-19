using Test2_Database_Library.Context;
using Test2_Database_Library.Entities;

namespace Test2_Database_Library.Repositories;

internal class UserRepo : Repo<UserEntity>
{
    private readonly DataContext _context;
    public UserRepo(DataContext context) : base(context)
    {
        _context = context;
    }
}
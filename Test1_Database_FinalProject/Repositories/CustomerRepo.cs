using Test1_Database_FinalProject.Context;
using Test1_Database_FinalProject.Entities;

namespace Test1_Database_FinalProject.Repositories;

internal class CustomerRepo : Repo<AddressEntity>
{
    private readonly DataContext _context;
    public CustomerRepo(DataContext context) : base(context)
    {
        _context = context;
    }
}

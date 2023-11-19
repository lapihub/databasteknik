using Test1_Database_FinalProject.Context;
using Test1_Database_FinalProject.Entities;

namespace Test1_Database_FinalProject.Repositories;

internal class OrderRepo : Repo<AddressEntity>
{
    private readonly DataContext _context;
    public OrderRepo(DataContext context) : base(context)
    {
        _context = context;
    }
}

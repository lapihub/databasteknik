using Test2_Database_Library.Context;
using Test2_Database_Library.Entities;

namespace Test2_Database_Library.Repositories;

internal class PublisherRepo : Repo<PublisherEntity>
{
    private readonly DataContext _context;
    public PublisherRepo(DataContext context) : base(context)
    {
        _context = context;
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Test1_Database_FinalProject.Entities;

internal class AddressEntity
{
    public int Id { get; set; }
    public string StreetName { get; set; } = null!;
    public string StreetNumber { get; set; } = null!;
    public int PostalCode { get; set; }
    public string City { get; set; } = null!;
    public string Country { get; set; } = null!;
}

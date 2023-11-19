using Microsoft.EntityFrameworkCore;

namespace Test1_Database_FinalProject.Entities;

[Index(nameof(Email), IsUnique = true)]
internal class SupplierEntity
{
    public int Id { get; set; }
    public string CompanyName { get; set; } = null!;
    public string ContactName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int AddressId { get; set; }
    public AddressEntity Address { get; set; } = null!;
}

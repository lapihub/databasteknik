using Microsoft.EntityFrameworkCore;

namespace Test1_Database_FinalProject.Entities;

[Index(nameof(Email), IsUnique = true)]
internal class CustomerEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;    
    public int AddressId { get; set; }
    public AddressEntity Address { get; set; } = null!;
}

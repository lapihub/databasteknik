using Microsoft.EntityFrameworkCore;

namespace Test2_Database_Library.Entities;

[Index(nameof(Email), IsUnique = true)]
internal class UserEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Title { get; set; }
}

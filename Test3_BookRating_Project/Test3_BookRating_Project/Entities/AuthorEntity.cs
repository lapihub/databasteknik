using System.ComponentModel.DataAnnotations;

namespace Test3_BookRating_Project.Entities;

internal class AuthorEntity
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

}

using System.ComponentModel.DataAnnotations;

namespace Test3_BookRating_Project.Entities;

internal class PublisherEntity
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}

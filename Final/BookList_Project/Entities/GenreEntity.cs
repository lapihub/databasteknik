using System.ComponentModel.DataAnnotations;

namespace BookList_Project.Entities;

internal class GenreEntity
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}


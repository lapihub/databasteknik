using System.ComponentModel.DataAnnotations;

namespace BookList_Project.Entities;

internal class BookEntity
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string PublishedYear { get; set; } = null!;
    public int AuthorId { get; set; }
    public AuthorEntity Author { get; set; } = null!;
    public int PublisherId { get; set; }
    public PublisherEntity Publisher { get; set; } = null!;
    public int GenreId { get; set; }
    public GenreEntity Genre { get; set; } = null!;
}


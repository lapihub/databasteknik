namespace Test2_Database_Library.Entities;

internal class BookEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ISBN { get; set; } = null!;
    public int? PublishedYear { get; set; }
    public int AuthorId { get; set; }
    public AuthorEntity Author { get; set; } = null!;
    public int PublishedId { get; set; }
    public PublisherEntity Publisher { get; set; } = null!;
}

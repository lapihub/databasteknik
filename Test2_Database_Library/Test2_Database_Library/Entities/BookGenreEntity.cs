namespace Test2_Database_Library.Entities;

internal class BookGenreEntity
{
    public int BookId { get; set; }
    public BookEntity Book { get; set; } = null!;
    public int GenreId { get; set; }
    public GenreEntity Genre { get; set; } = null!; 
}

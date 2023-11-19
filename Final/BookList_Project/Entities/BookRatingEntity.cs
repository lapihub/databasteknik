using System.ComponentModel.DataAnnotations;

namespace BookList_Project.Entities;

internal class BookRatingEntity
{
    [Key]
    public int Id { get; set; }
    public string ReviewText { get; set; } = null!;
    public string Rating { get; set; } = null!;
    public DateTime RatingDate { get; set; } = DateTime.Now;
    public int BookId { get; set; }
    public BookEntity Book { get; set; } = null!;
}


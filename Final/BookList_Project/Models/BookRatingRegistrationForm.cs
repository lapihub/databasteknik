namespace BookList_Project.Models;

internal class BookRatingRegistrationForm
{
    public string ReviewText { get; set; } = null!;
    public string Rating { get; set; } = null!;
    public DateTime RatingDate { get; set; } = DateTime.Now;
    public BookRegistrationForm Book { get; set; } = null!;
}


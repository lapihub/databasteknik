using Test3_BookRating_Project.Entities;

namespace Test3_BookRating_Project.Models;

internal class BookRegistrationForm
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string PublishedYear { get; set; } = null!;
    public AuthorRegistrationForm Author { get; set; } = null!;
    public PublisherRegistrationForm Publisher { get; set; } = null!;
    public GenreRegistrationForm Genre { get; set; } = null!;
}

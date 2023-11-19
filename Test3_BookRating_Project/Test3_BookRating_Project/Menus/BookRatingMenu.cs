using System.Diagnostics;
using System.Globalization;
using Test3_BookRating_Project.Models;
using Test3_BookRating_Project.Repositories;
using Test3_BookRating_Project.Services;

namespace Test3_BookRating_Project.Menus;

internal class BookRatingMenu
{
    private readonly BookRatingService _bookRatingService;
    private readonly BookService _bookService;

    public BookRatingMenu(BookRatingService bookRatingService, BookService bookService)
    {
        _bookRatingService = bookRatingService;
        _bookService = bookService;
    }

    public async Task CreateBookRatingAsync()
    {
        try
        {
            Console.Clear();
            Console.Write("------ RATE A BOOK ------");
            Console.WriteLine();

            Console.Write("Enter title of book you want to rate: ");
            var bookTitle = Console.ReadLine()!.Trim();

            var book = await _bookService.GetBookAsync(bookTitle);

            if (book == null)
            {
                Console.Clear();
                Console.WriteLine($"Book with title '{bookTitle}' not found.");
                Console.ReadKey();
                return;
            }

            var form = new BookRatingRegistrationForm();

            Console.WriteLine();
            Console.Write("Review the book: ");
            form.ReviewText = Console.ReadLine()!.Trim()!;

            Console.Write("Rate the book (1-5): ");
            form.Rating = Console.ReadLine()!.Trim();

            Console.Write("Rating Date (press any key to use current date & time): ");
            var dateInput = Console.ReadLine();

            if (string.IsNullOrEmpty(dateInput))
            {
                form.RatingDate = DateTime.Now;
            }
            else
            {
                if (DateTime.TryParseExact(dateInput, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ratingDate))
                {
                    form.RatingDate = ratingDate;
                }
                else
                {
                    Console.WriteLine("Invalid date format. Using the current date and time.");
                    form.RatingDate = DateTime.Now;
                }
            }

            form.Book = new BookRegistrationForm
            {
                Title = book.Title,
                Description = book.Description,
                PublishedYear = book.PublishedYear,
                Author = new AuthorRegistrationForm { FirstName = book.Author.FirstName, LastName = book.Author.LastName },
                Publisher = new PublisherRegistrationForm { Name = book.Publisher.Name },
                Genre = new GenreRegistrationForm { Name = book.Genre.Name },
            };

            var success = await _bookRatingService.CreateBookRatingAsync(form);
            
            if (success)
            {
                Console.WriteLine("Book rating has been created.");
            }
            else
            {
                Console.WriteLine($"Book rating not successful.");
            }
            Console.ReadKey();        
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
    }

    public async Task ListAllBookRatingsAsync()
    {
        try
        {
        Console.Clear();
        Console.WriteLine("----- ALL BOOK RATINGS -----");
        Console.WriteLine();

        var bookRatings = await _bookRatingService.GetAllRatingsAsync();
        
        if (bookRatings.Any())
        {
            foreach (var bookRating in bookRatings)
            {
                Console.WriteLine($"{bookRating.Book.Title} - {bookRating.Book.Author.FirstName} {bookRating.Book.Author.LastName} ");
                Console.WriteLine($"Book Rating: {bookRating.Rating}");
                Console.WriteLine($"Review: \n {bookRating.ReviewText}");
                Console.WriteLine($"Rating Date: {bookRating.RatingDate}");
                Console.WriteLine();
            }
        }
        else
            {
                Console.WriteLine("No book ratings found.");
            }
        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
    }

    public async Task ListBookRatingByBookAsync()
    {
        Console.Clear();
        Console.WriteLine("Enter the title of the book: ");
        var bookTitle = Console.ReadLine()!.Trim();

        var book = await _bookRatingService.GetRatingForBookAsync(bookTitle);

        if (book != null)
        {
            Console.Clear();
            Console.WriteLine($"---- BOOK RATING FOR '{bookTitle}' ----");
                Console.WriteLine();
                Console.WriteLine($"Book Rating: {book.Rating}");
                Console.WriteLine($"Review: {book.ReviewText}");
                Console.WriteLine($"Rating Date: {book.RatingDate}");
                Console.WriteLine();
        }
        else
        {
            Console.WriteLine($"No book ratings found for the book '{bookTitle}'");
        }
        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
    }

    public async Task UpdateBookRatingAsync()
    {
        Console.Clear();
        Console.WriteLine("Enter the title of the book: ");
        var bookTitle = Console.ReadLine()!.Trim();

        var book = await _bookRatingService.GetRatingForBookAsync(bookTitle);

        if (book != null)
        {
            Console.Clear();
            Console.WriteLine($"---- CURRENT BOOK RATING FOR '{bookTitle}' ----");
            Console.WriteLine($"Book Rating: {book.Rating}");
            Console.WriteLine($"Review: {book.ReviewText}");
            Console.WriteLine($"Rating Date: {book.RatingDate}");
            Console.WriteLine("------------------------------------------------");

            Console.WriteLine();
            Console.Write("Enter the new rating (1-5): ");
            var newRating = Console.ReadLine()!.Trim();

            Console.WriteLine();
            Console.Write("Enter the new review: ");
            var newReviewText = Console.ReadLine()!.Trim();

            Console.WriteLine();
            Console.Write("Do you want to update the rating date to current date and time? (Y/N): ");
            var updateRatingDate = Console.ReadLine()!.Trim().ToUpper();

            DateTime newRatingDate;
            if (updateRatingDate == "Y")
            {
                newRatingDate = DateTime.Now;
            }
            else
            {
                Console.WriteLine();
                Console.Write("Press any key to keep the last date and time: ");
                var ratingDateInput = Console.ReadLine();

                if (!string.IsNullOrEmpty(ratingDateInput) && DateTime.TryParse(ratingDateInput, out var parsedDate))
                {
                    newRatingDate = parsedDate;
                }
                else
                {
                    newRatingDate = book.RatingDate;
                }
            }
            var updatedBookRating = new BookRatingRegistrationForm
            {
                Rating = newRating,
                ReviewText = newReviewText,
                RatingDate = newRatingDate,
            };

            await _bookRatingService.UpdateBookRatingAsync(bookTitle, updatedBookRating);

            Console.Clear();
            Console.WriteLine($"Book rating for '{bookTitle}' has been updated.");
        }
        else
        {
            Console.Clear();
            Console.WriteLine($"No book rating found for the book '{bookTitle}'");
        }
        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
    }

}
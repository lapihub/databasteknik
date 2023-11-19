using System.Diagnostics;
using Test3_BookRating_Project.Entities;
using Test3_BookRating_Project.Models;
using Test3_BookRating_Project.Repositories;

namespace Test3_BookRating_Project.Services;

internal class BookRatingService
{
    private readonly BookRepo _bookRepo;
    private readonly BookRatingRepo _bookRatingRepo;
    private readonly BookService _bookService;

    public BookRatingService(BookRepo bookRepo, BookRatingRepo bookRatingRepo, BookService bookService)
    {
        _bookRepo = bookRepo;
        _bookRatingRepo = bookRatingRepo;
        _bookService = bookService;
    }

    public async Task<bool> CreateBookRatingAsync(BookRatingRegistrationForm form)
    {
        try
        {
            var book = await _bookRepo.GetAsync(x => x.Title == form.Book.Title);
            
            if (book != null)
            {
                var ratingEntity = new BookRatingEntity
                {
                    ReviewText = form.ReviewText,
                    Rating = form.Rating,
                    RatingDate = form.RatingDate,
                    BookId = book.Id,
                };

                await _bookRatingRepo.CreateAsync(ratingEntity);
                return true;
            }
            else
            {
                return false;
            }
        } catch (Exception ex) { Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<IEnumerable<BookRatingEntity>> GetAllRatingsAsync()
    {
        try
        {
            var books = await _bookService.GetAllAsync();
            var ratings = new List<BookRatingEntity>();

            foreach (var book in books)
            {
                var bookRatings = await _bookRatingRepo.GetAsync(x => x.Book.Title == book.Title);
            }
            return ratings;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message);
            return Enumerable.Empty<BookRatingEntity>(); }
    }

    public async Task<BookRatingEntity?> GetRatingForBookAsync(string title)
    {
        try
        {
            var book = await _bookService.GetBookAsync(title);

            if (book != null)
            {
                var bookRating = await _bookRatingRepo.GetAsync(x => x.Book.Id == book.Id);
                return bookRating;
            }
            return null;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message);
        return null;}
    }
    public async Task<bool> UpdateBookRatingAsync(string title, BookRatingRegistrationForm form)
    {
        try
        {
            var book = await _bookService.GetBookAsync(title);

            if (book != null)
            {
                var rating = await _bookRatingRepo.GetAsync(x => x.Book.Title == book.Title);

                if (rating != null)
                {
                    rating.ReviewText = form.ReviewText;
                    rating.Rating = form.Rating;
                    rating.RatingDate = form.RatingDate;

                    await _bookRatingRepo.UpdateAsync(rating);

                    return true;

                }
                else
                    return false;
            }
            else
                return false;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
    }

    public async Task<bool> DeleteBookRatingAsync(string title)
    {
        try
        {
            var rating = await _bookRatingRepo.GetAsync(x => x.Book.Title == title);
            
            if (rating != null)
            {
                return await _bookRatingRepo.DeleteAsync(x => x.Book.Title == title);
            }
            else
            {
                Debug.WriteLine($"Book Rating with title '{title}' was not found for deletion.");
                return false;
            }
        }
        catch (Exception ex) { Debug.Write(ex.Message); return false; }

    }
}

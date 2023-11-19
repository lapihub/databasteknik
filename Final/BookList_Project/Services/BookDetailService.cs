using BookList_Project.Entities;
using BookList_Project.Repos;
using System.Diagnostics;

namespace BookList_Project.Services;

internal class BookDetailService
{
    private readonly AuthorRepo _authorRepo;
    private readonly GenreRepo _genreRepo;
    private readonly PublisherRepo _publisherRepo;
    private readonly BookRepo _bookRepo;

    public BookDetailService(AuthorRepo authorRepo, GenreRepo genreRepo, PublisherRepo publisherRepo, BookRepo bookRepo)
    {
        _authorRepo = authorRepo;
        _genreRepo = genreRepo;
        _publisherRepo = publisherRepo;
        _bookRepo = bookRepo;
    }

    // Author
    public async Task<IEnumerable<AuthorEntity>> GetAllAuthorsAsync()
    {
        try
        {
            var author = await _authorRepo.GetAllAsync();
            return author;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public async Task<IEnumerable<BookEntity>?> GetBooksByAuthorAsync(string firstName, string lastName)
    {
        try
        {
            return await _authorRepo.GetBooksByAuthorAsync(firstName, lastName);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return Enumerable.Empty<BookEntity>();
        }
    }

    // Genre
    public async Task<IEnumerable<GenreEntity>> GetAllGenresAsync()
    {
        try
        {
            var genre = await _genreRepo.GetAllAsync();
            return genre;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public async Task<IEnumerable<BookEntity>?> GetBooksByGenreAsync(string name)
    {
        try
        {
            return await _genreRepo.GetBooksByGenreAsync(name);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return Enumerable.Empty<BookEntity>();
        }

    }

    // Publisher
    public async Task<IEnumerable<PublisherEntity>> GetAllPublishersAsync()
    {
        try
        {
            var publisher = await _publisherRepo.GetAllAsync();
            return publisher;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public async Task<IEnumerable<BookEntity>?> GetBooksByPublisherAsync(string name)
    {
        try
        {
            return await _publisherRepo.GetBooksByPublisherAsync(name);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return Enumerable.Empty<BookEntity>();
        }
    }
}

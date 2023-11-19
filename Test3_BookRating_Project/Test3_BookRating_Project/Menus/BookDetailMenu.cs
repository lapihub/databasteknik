using System.ComponentModel.Design;
using System.Diagnostics;
using Test3_BookRating_Project.Services;

namespace Test3_BookRating_Project.Menus;

internal class BookDetailMenu
{
    private readonly BookDetailService _bookDetailService;

    public BookDetailMenu(BookDetailService bookDetailService)
    {
        _bookDetailService = bookDetailService;
    }

    // ---------- AUTHOR ----------
    public async Task ListAllAuthorsAsync()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("------ ALL AUTHORS ------");
            Console.WriteLine();

            var authors = await _bookDetailService.GetAllAuthorsAsync();
            if (authors != null && authors.Any())
            {
                var uniqueAuthors = new HashSet<string>();

                foreach (var author in authors)
                {
                    var fullName = $"{author.FirstName} {author.LastName}";
                    if (uniqueAuthors.Add(fullName))
                    {
                        Console.WriteLine($"{fullName}");
                        Console.WriteLine();
                    }
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Booklist is empty. No authors can be shown.");
                Console.ReadKey();
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
    }

    public async Task ListBooksByAuthorAsync()
    {
        Console.Clear();
        Console.WriteLine("All Books by Author");
        Console.WriteLine("---------------------");

        Console.Write("Enter author's first name: ");
        var firstName = Console.ReadLine()!.Trim();

        Console.Write("Enter author's last name: ");
        var lastName = Console.ReadLine()!.Trim();

        var booksByAuthor = await _bookDetailService.GetBooksByAuthorAsync(firstName, lastName);

        if (booksByAuthor != null && booksByAuthor.Any())
        {
            Console.WriteLine();
            Console.WriteLine($"Books by {firstName} {lastName}: ");
            Console.WriteLine();
            foreach (var book in booksByAuthor)
            {
                Console.WriteLine($"{book.Title} ({book.PublishedYear}) \n Genre: {book.Genre.Name} \n Publisher: {book.Publisher.Name} \n Description: {book.Description}");
                Console.WriteLine();
            }
        }
        else if (booksByAuthor != null && !booksByAuthor.Any())
        {
            Console.Clear();
            Console.WriteLine($"No books added in booklist by Author: {firstName} {lastName}");          
        }
        else
        {
            Console.Clear();
            Console.WriteLine("An error occurred while fetching books by author.");
        }
        Console.ReadKey();
    }

    // ---------- GENRE ----------

    public async Task ListAllGenresAsync()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("------ ALL GENRES ------");
            Console.WriteLine();

            var genres = await _bookDetailService.GetAllGenresAsync();
            if (genres != null && genres.Any())
            {
                var uniqueGenres = new HashSet<string>();

                foreach (var genre in genres)
                {
                    if (uniqueGenres.Add(genre.Name))
                    {
                    Console.WriteLine($"{genre.Name}");
                    Console.WriteLine("");
                    }
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Booklist is empty. No genres can be shown.");
                Console.ReadKey();
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
    }

    public async Task ListBooksByGenreAsync()
    {
        Console.Clear();
        Console.WriteLine("All Books by Genre");
        Console.WriteLine("---------------------");

        Console.Write("Enter Genre-Name: ");
        var GenreName = Console.ReadLine()!.Trim();

        var booksByGenre = await _bookDetailService.GetBooksByGenreAsync(GenreName);

        if (booksByGenre != null && booksByGenre.Any())
        {
            Console.WriteLine();
            Console.WriteLine($"Books with Genre: {GenreName}: ");
            Console.WriteLine();
            foreach (var book in booksByGenre)
            {
                Console.WriteLine($"{book.Title} - {book.Author.FirstName} {book.Author.LastName} ({book.PublishedYear}) \n Publisher: {book.Publisher.Name} \n Description: {book.Description}");
                Console.WriteLine();
            }
        }
        else if (booksByGenre != null && !booksByGenre.Any())
        {
            Console.Clear();
            Console.WriteLine($"No books added in booklist with Genre: {GenreName}");
        }
        else
        {
            Console.Clear();
            Console.WriteLine("An error occurred while fetching books by genre.");
        }
        Console.ReadKey();
    }

    // ---------- PUBLISHER ----------

    public async Task ListAllPublishersAsync()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("------ ALL PUBLISHERS ------");
            Console.WriteLine();

            var publishers = await _bookDetailService.GetAllPublishersAsync();
            if (publishers != null && publishers.Any())
            {
                var uniquePublisher = new HashSet<string>();

                foreach (var publisher in publishers)
                {
                    if (uniquePublisher.Add(publisher.Name))
                    {
                    Console.WriteLine($"{publisher.Name}");
                    Console.WriteLine("");
                    }
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Booklist is empty. No publishers can be shown.");
                Console.ReadKey();
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
    }

    public async Task ListBooksByPublisherAsync()
    {
        Console.Clear();
        Console.WriteLine("All Books by Publisher");
        Console.WriteLine("---------------------");

        Console.Write("Enter Publisher-Name: ");
        var PublisherName = Console.ReadLine()!.Trim();

        var booksByPublisher = await _bookDetailService.GetBooksByPublisherAsync(PublisherName);

        if (booksByPublisher != null && booksByPublisher.Any())
        {
            Console.WriteLine();
            Console.WriteLine($"Books with Publisher: {PublisherName}: ");
            Console.WriteLine();
            foreach (var book in booksByPublisher)
            {
                Console.WriteLine($"{book.Title} - {book.Author.FirstName} {book.Author.LastName} ({book.PublishedYear}) \n Genre: {book.Genre.Name} \n Description: {book.Description}");
                Console.WriteLine();
            }
        }
        else if (booksByPublisher != null && !booksByPublisher.Any())
        {
            Console.Clear();
            Console.WriteLine($"No books added in booklist with Publisher: {PublisherName}");
        }
        else
        {
            Console.Clear();
            Console.WriteLine("An error occurred while fetching books by publisher.");
        }
        Console.ReadKey();
    }

}

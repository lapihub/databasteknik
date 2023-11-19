using BookList_Project.Entities;
using BookList_Project.Models;
using BookList_Project.Services;
using System.Diagnostics;

namespace BookList_Project.Menus;

internal class BookMenu
{
    private readonly BookService _bookService;

    public BookMenu(BookService bookService)
    {
        _bookService = bookService;
    }

    public async Task CreateAsync()
    {
        try
        {
            var form = new BookRegistrationForm();

            Console.Clear();
            Console.Write("---- ADD BOOK ----");
            Console.WriteLine();
            Console.Write("Title: ");
            form.Title = Console.ReadLine()!.Trim()!;

            form.Author = new AuthorRegistrationForm();

            Console.Write("Author's First Name: ");
            form.Author.FirstName = Console.ReadLine()!.Trim()!;

            Console.Write("Author's Last Name: ");
            form.Author.LastName = Console.ReadLine()!.Trim()!;

            form.Genre = new GenreRegistrationForm();

            Console.Write("Genre: ");
            form.Genre.Name = Console.ReadLine()!.Trim()!;

            form.Publisher = new PublisherRegistrationForm();

            Console.Write("Publisher: ");
            form.Publisher.Name = Console.ReadLine()!.Trim()!;

            Console.Write("Published Year: ");
            form.PublishedYear = Console.ReadLine()!.Trim()!;

            Console.Write("Description of book: ");
            form.Description = Console.ReadLine()!.Trim()!;

            var result = await _bookService.CreateBookAsync(form);
            if (result)
            {
                Console.WriteLine();
                Console.WriteLine("Book was successfully added to Booklist!");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Unable to add book to Booklist. Please try again.");
            }

            Console.ReadKey();
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

    }

    public async Task ListAllAsync()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("-------- BOOKLIST --------");
            Console.WriteLine();

            var books = await _bookService.GetAllAsync();
            if (books != null && books.Any())
            {
                foreach (var book in books)
                {
                    Console.WriteLine($"{book.Title} - {book.Author.FirstName} {book.Author.LastName} ({book.PublishedYear}) \n Genre: {book.Genre.Name} \n Publisher: {book.Publisher.Name} \n Description: {book.Description}");
                    Console.WriteLine("");
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Booklist is empty. Please add a book to list to view details!");
            }
            Console.ReadKey();

        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

    }

    public async Task ListSpecificAsync()
    {
        Console.Clear();
        Console.WriteLine("Search for book in booklist");
        Console.WriteLine("----------------------------");
        Console.WriteLine("Name Title of the book: ");

        var title = Console.ReadLine()!.Trim();
        var book = await _bookService.GetBookAsync(title);

        if (book != null)
        {
            Console.WriteLine();
            Console.WriteLine($"{book.Title} - {book.Author.FirstName} {book.Author.LastName} ({book.PublishedYear}) \n Genre: {book.Genre.Name} \n Publisher: {book.Publisher.Name} \n Description: {book.Description}");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine($"Could not find book with Title '{title}'");
        }
        Console.ReadKey();

    }

    public async Task UpdateAsync()
    {
        Console.Clear();
        Console.WriteLine("Update an existing book in booklist");
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("Name Title of book: ");
        var title = Console.ReadLine()!.Trim();

        var book = await _bookService.GetBookAsync(title);
        if (book != null)
        {
            Console.Clear();
            Console.WriteLine(" Current details of book");
            Console.WriteLine("--------------------------");
            Console.WriteLine($"{book.Title} - {book.Author.FirstName} {book.Author.LastName} ({book.PublishedYear}) \n Genre: {book.Genre.Name} \n Publisher: {book.Publisher.Name} \n Description: {book.Description}");

            Console.WriteLine();
            Console.WriteLine("Update the fields where changes are desired. Leave other fields empty.");
            Console.WriteLine();

            Console.Write("Update title: ");
            var newTitle = Console.ReadLine()!.Trim();
            if (!string.IsNullOrEmpty(newTitle)) book.Title = newTitle;

            book.Author ??= new AuthorEntity();

            Console.Write("Update author's first name: ");
            var newFirstName = Console.ReadLine()!.Trim();
            if (!string.IsNullOrEmpty(newFirstName)) book.Author.FirstName = newFirstName;

            Console.Write("Update author's last name: ");
            var newLastName = Console.ReadLine()!.Trim();
            if (!string.IsNullOrEmpty(newLastName)) book.Author.LastName = newLastName;

            Console.Write("Update published year: ");
            var newYear = Console.ReadLine()!.Trim();
            if (!string.IsNullOrEmpty(newYear)) book.PublishedYear = newYear;

            book.Genre ??= new GenreEntity();

            Console.Write("Update genre: ");
            var newGenre = Console.ReadLine()!.Trim();
            if (!string.IsNullOrEmpty(newGenre)) book.Genre.Name = newGenre;

            book.Publisher ??= new PublisherEntity();

            Console.Write("Update publisher: ");
            var newPublisher = Console.ReadLine()!.Trim();
            if (!string.IsNullOrEmpty(newPublisher)) book.Publisher.Name = newPublisher;

            Console.Write("Update description: ");
            var newDescription = Console.ReadLine()!.Trim();
            if (!string.IsNullOrEmpty(newDescription)) book.Description = newDescription;

            await _bookService.UpdateBookAsync(book);

            Console.WriteLine("---------------------------");
            Console.WriteLine("Book is now updated!");
        }
        else
        {
            Console.Clear();
            Console.WriteLine($"Could not find book with Title '{title}'.");
        }
        Console.ReadKey();
    }

    public async Task DeleteAsync()
    {
        Console.Clear();
        Console.WriteLine("Name title of book: ");
        Console.WriteLine("--------------------");

        var title = Console.ReadLine()!.Trim();
        var book = await _bookService.GetBookAsync(title);

        if (book != null)
        {
            Console.Clear();
            Console.WriteLine($"{book.Title} - {book.Author.FirstName} {book.Author.LastName} ({book.PublishedYear}) \n Genre: {book.Genre.Name} \n Publisher: {book.Publisher.Name} \n Description: {book.Description}");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Press any key to remove book from booklist.");
            Console.ReadKey();

            try
            {
                await _bookService.DeleteBookAsync(new string(title));
            }
            catch { }

            Console.Clear();
            Console.WriteLine("Your chosen book have now been removed from booklist!");
        }
        else
        {
            Console.Clear();
            Console.WriteLine($"Could not find book with title '{title}'.");
        }
        Console.ReadKey();
    }
}

namespace Test3_BookRating_Project.Menus;

internal class MainMenu
{
    private readonly BookMenu _bookMenu;
    private readonly BookDetailMenu _bookDetailMenu;
    private readonly BookRatingMenu _bookRatingMenu;

    public MainMenu(BookMenu bookmenu, BookDetailMenu bookdetailmenu, BookRatingMenu bookRatingMenu)
    {
        _bookMenu = bookmenu;
        _bookDetailMenu = bookdetailmenu;
        _bookRatingMenu = bookRatingMenu;
    }

    public async Task StartAsync()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("------ MAIN MENU ------");
            Console.WriteLine("1. Manage Books");
            Console.WriteLine("2. Manage Authors");
            Console.WriteLine("3. Manage Genres");
            Console.WriteLine("4. Manage Publishers");
            Console.WriteLine("5. Manage Book Ratings");
            Console.WriteLine("Choose one option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await ManageBooks();
                    break;
                case "2":
                    await ManageAuthors();
                    break;
                case "3":
                    await ManageGenres();
                    break;
                case "4":
                    await ManagePublishers();
                    break;
                case "5":
                    await ManageBookRatings();
                    break;
            }

        } while (true);
    }

    public async Task ManageBooks()
    {
        var exit = false;
        do
        {


            Console.Clear();
            Console.WriteLine("------------- BOOKS ------------- ");
            Console.WriteLine("1. View all books in booklist");
            Console.WriteLine("2. View specific book in booklist");
            Console.WriteLine("3. Add book to booklist");
            Console.WriteLine("4. Update book in booklist");
            Console.WriteLine("5. Remove book from booklist");
            Console.WriteLine("0. Exit");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await _bookMenu.ListAllAsync();
                    break;
                case "2":
                    await _bookMenu.ListSpecificAsync();
                    break;
                case "3":
                    await _bookMenu.CreateAsync();
                    break;
                case "4":
                    await _bookMenu.UpdateAsync();
                    break;
                case "5":
                    await _bookMenu.DeleteAsync();
                    break;
                case "0":
                    exit = true;
                    break;
            }
        } while (exit == false);

    }

    public async Task ManageAuthors()
    {
        var exit = false;
        do
        {

            Console.Clear();
            Console.WriteLine("--------------- AUTHORS ---------------");
            Console.WriteLine("1. View all authors from booklist");
            Console.WriteLine("2. View all books from specific author");
            Console.WriteLine("0. Exit");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await _bookDetailMenu.ListAllAuthorsAsync();
                    break;
                case "2":
                    await _bookDetailMenu.ListBooksByAuthorAsync();
                    break;
                case "0":
                    exit = true;
                    break;
            }
        } while (exit == false);
    }

    public async Task ManageGenres()
    {
        var exit = false;
        do 
        { 
        Console.Clear();
        Console.WriteLine("-------------- GENRES --------------");
        Console.WriteLine("1. View all genres from booklist");
        Console.WriteLine("2. View all books from specific genre");
        Console.WriteLine("0. Exit");
        var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await _bookDetailMenu.ListAllGenresAsync();
                    break;
                case "2":
                    await _bookDetailMenu.ListBooksByGenreAsync();
                    break;
                case "0":
                    exit = true;
                    break;
            }
        } while (exit == false);
    }

    public async Task ManagePublishers()
    {
        var exit = false;
        do 
        { 
        Console.Clear();
        Console.WriteLine("-------------- PUBLISHERS --------------");
        Console.WriteLine("1. View all publishers from booklist");
        Console.WriteLine("2. View all books from specific publisher");
        Console.WriteLine("0. Exit");
        var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await _bookDetailMenu.ListAllPublishersAsync();
                    break;
                case "2":
                    await _bookDetailMenu.ListBooksByPublisherAsync();
                    break;
                case "0":
                    exit = true;
                    break;
            }
        } while ( exit == false);
    }

    public async Task ManageBookRatings()
    {
        var exit = false;
        do
        {
            Console.Clear();
            Console.WriteLine("-------------- BOOK RATINGS --------------");
            Console.WriteLine("1. View all book ratings from booklist");
            Console.WriteLine("2. View book rating from specific book");
            Console.WriteLine("3. Rate a book from booklist");
            Console.WriteLine("4. Update book rating from specific book");
            Console.WriteLine("0. Exit");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await _bookRatingMenu.ListAllBookRatingsAsync();
                    break;
                case "2":
                    await _bookRatingMenu.ListBookRatingByBookAsync();
                    break;
                case "3":
                    await _bookRatingMenu.CreateBookRatingAsync();
                    break;
                case "4":
                    await _bookRatingMenu.UpdateBookRatingAsync();
                    break;
                case "0":
                    exit = true;
                    break;
            }
        } while (exit == false);
    }
}

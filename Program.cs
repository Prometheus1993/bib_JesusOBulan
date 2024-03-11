// Purpose: Main program file for the Library project.


namespace Library
{
    public class Program
    {
        private static Book newBook;
        private static Library myLibrary;

        static void Main()
        {

            myLibrary = new("My Library");


            string filePath = "csv/books.csv";

            List<Book> booksFromCsv = Book.DeserializeFromCSV(filePath, myLibrary);

            foreach (var book in booksFromCsv)
            {
                myLibrary.AddBook(book);
            }

            while (true)
            {
                System.Console.WriteLine("1 - Voeg een boek toe aan de bibliotheek");
                System.Console.WriteLine("2 - Voeg informatie toe aan een boek");
                System.Console.WriteLine("3 - Toon informatie over een boek");
                System.Console.WriteLine("4 - Zoek een boek in de bibliotheek");
                System.Console.WriteLine("5 - Verwijder een boek uit de bibliotheek");
                System.Console.WriteLine("6 - Toon alle boeken in de bibliotheek");
                System.Console.WriteLine("7 - Verlaat de bibliotheek");

                if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 7)
                {
                    System.Console.WriteLine("Ongeldige keuze! Probeer opnieuw.");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                Console.Clear();

                switch (choice)
                {
                    case 1:
                        Addbook();
                        break;
                    case 2:
                        AddInfoToBook();
                        break;
                    case 3:
                        ShowInfoOfBook();
                        break;
                    case 4:
                        SearchForBook();
                        break;
                    case 5:
                        RemoveBook();
                        break;
                    case 6:
                        myLibrary.ShowAllBooks();
                        break;
                    case 7:
                        System.Console.WriteLine("Tot Ziens!");
                        Thread.Sleep(1000);
                        break;
                }
                if (choice == 7)
                {
                    break;
                }
            }

        }

        // Methods for the menu

        // Add a book to the library
        static void Addbook()
        {

            System.Console.WriteLine("Voeg een boek toe aan de bibliotheek");
            System.Console.WriteLine("Geef de titel van het boek in:");
            string title = Console.ReadLine();
            System.Console.WriteLine("Geef de auteur van het boek in:");
            string author = Console.ReadLine();
            newBook = new Book(title, author, myLibrary);
            myLibrary.AddBook(newBook);
        }
        // Add information to a book
        static void AddInfoToBook()
        {
            System.Console.WriteLine("Geef de titel van het boek in:");
            string titleInfo = Console.ReadLine();
            System.Console.WriteLine("Geef de auteur van het boek in:");
            string authorInfo = Console.ReadLine();
            Book bookInfo = myLibrary.SearchBookByTitleAuthor(titleInfo, authorInfo);
            if (bookInfo != null)
            {
                int choiceInfo = 0;
                while (choiceInfo != 7)
                {
                    System.Console.WriteLine("Wat wil je toevoegen?");
                    System.Console.WriteLine("1 - ISBN");
                    System.Console.WriteLine("2 - Publicatie jaar");
                    System.Console.WriteLine("3 - Pagina's");
                    System.Console.WriteLine("4 - Taal");
                    System.Console.WriteLine("5 - Uitgever");
                    System.Console.WriteLine("6 - Genre");
                    System.Console.WriteLine("7 - Terug");
                    if (!int.TryParse(Console.ReadLine(), out choiceInfo) || choiceInfo < 1 || choiceInfo > 7)
                    {
                        System.Console.WriteLine("Ongeldige keuze! Probeer opnieuw.");
                        Console.ReadKey();
                        Console.Clear();
                        return;
                    }
                    Console.Clear();
                    switch (choiceInfo)
                    {
                        case 1:
                            System.Console.WriteLine("Geef de ISBN van het boek in:");
                            string newIsbn = Console.ReadLine();
                            bookInfo.IsbnNumber = newIsbn;
                            break;
                        case 2:
                            System.Console.WriteLine("Geef het publicatie jaar van het boek in:");
                            int publicationYear = int.Parse(Console.ReadLine());
                            bookInfo.PublicationYear = publicationYear;
                            break;
                        case 3:
                            System.Console.WriteLine("Geef het aantal pagina's van het boek in:");
                            int pageCount = int.Parse(Console.ReadLine());
                            bookInfo.PageCount = pageCount;
                            break;
                        case 4:
                            System.Console.WriteLine("Geef de taal van het boek in:");
                            string language = Console.ReadLine();
                            bookInfo.Language = language;
                            break;
                        case 5:
                            System.Console.WriteLine("Geef de uitgever van het boek in:");
                            string publisher = Console.ReadLine();
                            bookInfo.Publisher = publisher;
                            break;
                        case 6:
                            System.Console.WriteLine("Geef het genre van het boek in:");
                            string genreInput = Console.ReadLine();
                            if (Enum.TryParse(genreInput, out Genre genre))
                            {
                                bookInfo.GenreBook = genre;
                            }
                            else
                            {
                                System.Console.WriteLine("Ongeldig genre! Probeer opnieuw.");
                                Console.ReadKey();
                                Console.Clear();
                                return;
                            }
                            break;
                        case 7:
                            break;
                    }
                }
            }
            else
            {
                System.Console.WriteLine("Boek niet gevonden!");
            }
        }

        // Show information of a book
        static void ShowInfoOfBook()
        {
            System.Console.WriteLine("Op welke manier wil je zoeken?");
            System.Console.WriteLine("1 - ISBN");
            System.Console.WriteLine("2 - Titel");
            System.Console.WriteLine("3 - Auteur");
            System.Console.WriteLine("4 - Terug");
            if (!int.TryParse(Console.ReadLine(), out int choiceSearch) || choiceSearch < 1 || choiceSearch > 4)
            {
                System.Console.WriteLine("Ongeldige keuze! Probeer opnieuw.");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            Console.Clear();
            switch (choiceSearch)
            {
                case 1:
                    System.Console.WriteLine("Geef de ISBN van het boek in:");
                    string isbnSearch = Console.ReadLine();
                    Book bookIsbn = myLibrary.SearchBookByISBN(isbnSearch);
                    if (bookIsbn != null)
                    {
                        bookIsbn.ShowInfo();
                    }
                    else
                    {
                        System.Console.WriteLine("Boek niet gevonden!");
                    }
                    break;
                case 2:
                    System.Console.WriteLine("Geef de titel van het boek in:");
                    string searchTitle = Console.ReadLine();
                    Book bookTitle = myLibrary.SearchBookByTitle(searchTitle);
                    if (bookTitle != null)
                    {
                        bookTitle.ShowInfo();
                    }
                    else
                    {
                        System.Console.WriteLine("Boek niet gevonden!");
                    }
                    break;
                case 3:
                    System.Console.WriteLine("Geef de auteur van het boek in:");
                    string searchAuthor = Console.ReadLine();
                    Book bookAuthor = myLibrary.SearchBooksByAuthor(searchAuthor);
                    if (bookAuthor != null)
                    {
                        bookAuthor.ShowInfo();
                    }
                    else
                    {
                        System.Console.WriteLine("Boek niet gevonden!");
                    }
                    break;
            }
        }
        // Search for a book
        static void SearchForBook()
        {
            System.Console.WriteLine("Op welke manier wil je zoeken?");
            System.Console.WriteLine("1 - ISBN");
            System.Console.WriteLine("2 - Titel");
            System.Console.WriteLine("3 - Auteur");
            System.Console.WriteLine("4 - Terug");
            if (!int.TryParse(Console.ReadLine(), out int choiceSearch) || choiceSearch < 1 || choiceSearch > 4)
            {
                System.Console.WriteLine("Ongeldige keuze! Probeer opnieuw.");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            Console.Clear();
            switch (choiceSearch)
            {
                case 1:
                    System.Console.WriteLine("Geef de ISBN van het boek in:");
                    string isbnSearch = Console.ReadLine();
                    Book bookIsbn = myLibrary.SearchBookByISBN(isbnSearch);
                    if (bookIsbn != null)
                    {
                        bookIsbn.ShowInfo();
                    }
                    else
                    {
                        System.Console.WriteLine("Boek niet gevonden!");
                    }
                    break;
                case 2:
                    System.Console.WriteLine("Geef de titel van het boek in:");
                    string searchTitle = Console.ReadLine();
                    Book bookTitle = myLibrary.SearchBookByTitle(searchTitle);
                    if (bookTitle != null)
                    {
                        bookTitle.ShowInfo();
                    }
                    else
                    {
                        System.Console.WriteLine("Boek niet gevonden!");
                    }
                    break;
                case 3:
                    System.Console.WriteLine("Geef de auteur van het boek in:");
                    string searchAuthor = Console.ReadLine();
                    Book bookAuthor = myLibrary.SearchBooksByAuthor(searchAuthor);
                    if (bookAuthor != null)
                    {
                        bookAuthor.ShowInfo();
                    }
                    else
                    {
                        System.Console.WriteLine("Boek niet gevonden!");
                    }
                    break;
            }
        }
        // Remove a book from the library
        static void RemoveBook()
        {
            System.Console.WriteLine("Op welke manier wil je zoeken?");
            System.Console.WriteLine("1 - ISBN");
            System.Console.WriteLine("2 - Titel");
            System.Console.WriteLine("3 - Auteur");
            System.Console.WriteLine("4 - Terug");
            if (!int.TryParse(Console.ReadLine(), out int choiceSearch) || choiceSearch < 1 || choiceSearch > 4)
            {
                System.Console.WriteLine("Ongeldige keuze! Probeer opnieuw.");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            Console.Clear();
            switch (choiceSearch)
            {
                case 1:
                    System.Console.WriteLine("Geef de ISBN van het boek in:");
                    string isbnSearch = Console.ReadLine();
                    myLibrary.RemoveBook(isbnSearch);
                    break;
                case 2:
                    System.Console.WriteLine("Geef de titel van het boek in:");
                    string searchTitle = Console.ReadLine();
                    Book bookTitle = myLibrary.SearchBookByTitle(searchTitle);
                    if (bookTitle != null)
                    {
                        myLibrary.RemoveBook(bookTitle.IsbnNumber);
                    }
                    else
                    {
                        System.Console.WriteLine("Boek niet gevonden!");
                    }
                    break;
                case 3:
                    System.Console.WriteLine("Geef de auteur van het boek in:");
                    string searchAuthor = Console.ReadLine();
                    Book bookAuthor = myLibrary.SearchBooksByAuthor(searchAuthor);
                    if (bookAuthor != null)
                    {
                        myLibrary.RemoveBook(bookAuthor.IsbnNumber);
                    }
                    else
                    {
                        System.Console.WriteLine("Boek niet gevonden!");
                    }
                    break;
            }
        }

    }
}

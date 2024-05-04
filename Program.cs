// Purpose: Main program file for the Library project.




namespace bib_JesusOBulan
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
                System.Console.WriteLine("7 - Voeg een krant toe aan de leeszaal");
                System.Console.WriteLine("8 - Voeg een magazine toe aan de leeszaal");
                System.Console.WriteLine("9 - Toon alle kranten in de leeszaal");
                System.Console.WriteLine("10 - Toon alle magazines in de leeszaal");
                System.Console.WriteLine("11 - Bekijk nieuwe aanwinsten van de leeszaal");
                System.Console.WriteLine("12 - Leen een boek");
                System.Console.WriteLine("13 - breng een boek terug");
                System.Console.WriteLine("14 - Verlaat de bibliotheek");

                if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 14)
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
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 7:
                        myLibrary.AddNewspaper();
                        break;
                    case 8:
                        myLibrary.AddMagazine();
                        break;
                    case 9:
                        myLibrary.ShowAllNewspapers();
                        break;
                    case 10:
                        myLibrary.ShowAllMagazines();
                        break;
                    case 11:
                        myLibrary.AcquisitionsReadingRoomToday();
                        break;
                    case 12:
                        BorrowBook();
                        break;
                    case 13:
                        ReturnBook();
                        break;
                    case 14:
                        System.Console.WriteLine("Tot Ziens!");
                        Thread.Sleep(1000);
                        break;
                }
                if (choice == 14)
                {
                    break;
                }
            }

        }

        // Methods for the menu

        // Add a book to the library
        static void Addbook()
        {
            try
            {
                System.Console.WriteLine("Voeg een boek toe aan de bibliotheek\n");
                System.Console.WriteLine("Geef de titel van het boek in:");
                string title = Console.ReadLine();
                System.Console.WriteLine("\nGeef de auteur van het boek in:");
                string author = Console.ReadLine();

                newBook = new Book(title, author, myLibrary, Genre.Schoolboek);
                myLibrary.AddBook(newBook);

                System.Console.WriteLine("Boek toegevoegd!\n");
                Console.ReadKey();
                Console.Clear();
            }
            catch (InvalidBookPropertyException bex)
            {
                System.Console.WriteLine($"Fout bij het toevoegen van het boek: {bex.Message}");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Een onverwachte fout is opgetreden: {ex.Message}");
                Console.ReadKey();
            }
        }
        // Add information to a book
        static void AddInfoToBook()
        {
            try
            {
                System.Console.WriteLine("Geef de titel van het boek in:");
                string titleInfo = Console.ReadLine();
                System.Console.WriteLine("Geef de auteur van het boek in:");
                string authorInfo = Console.ReadLine();
                Book bookInfo = myLibrary.SearchBookByTitleAuthor(titleInfo, authorInfo);

                if (bookInfo == null)
                    throw new BookNotFoundException("Boek niet gevonden!");

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
                        continue;
                    }
                    Console.Clear();

                    switch (choiceInfo)
                    {
                        case 1:
                            System.Console.WriteLine("Geef de ISBN van het boek in:");
                            string newIsbn = Console.ReadLine();
                            bookInfo.IsbnNumber = newIsbn;
                            System.Console.WriteLine("ISBN bijgewerkt!");
                            break;
                        case 2:
                            System.Console.WriteLine("Geef het publicatie jaar van het boek in:");
                            if (int.TryParse(Console.ReadLine(), out int publicationYear))
                            {
                                bookInfo.PublicationYear = publicationYear;
                                System.Console.WriteLine("Publicatiejaar bijgewerkt!");
                            }
                            else
                            {
                                System.Console.WriteLine("Ongeldige invoer voor het publicatie jaar.");
                            }
                            break;
                        case 3:
                            System.Console.WriteLine("Geef het aantal pagina's van het boek in:");
                            if (int.TryParse(Console.ReadLine(), out int pageCount))
                            {
                                bookInfo.PageCount = pageCount;
                                System.Console.WriteLine("Aantal pagina's bijgewerkt!");
                            }
                            else
                            {
                                System.Console.WriteLine("Ongeldige invoer voor pagina's.");
                            }
                            break;
                        case 4:
                            System.Console.WriteLine("Geef de taal van het boek in:");
                            string language = Console.ReadLine();
                            bookInfo.Language = language;
                            System.Console.WriteLine("Taal bijgewerkt!");
                            break;
                        case 5:
                            System.Console.WriteLine("Geef de uitgever van het boek in:");
                            string publisher = Console.ReadLine();
                            bookInfo.Publisher = publisher;
                            System.Console.WriteLine("Uitgever bijgewerkt!");
                            break;
                        case 6:
                            System.Console.WriteLine("Geef het genre van het boek in:");
                            string genreInput = Console.ReadLine();
                            if (Enum.TryParse(genreInput, out Genre genre))
                            {
                                bookInfo.GenreBook = genre;
                                System.Console.WriteLine("Genre bijgewerkt!");
                            }
                            else
                            {
                                System.Console.WriteLine("Ongeldig genre! Probeer opnieuw.");
                            }
                            break;
                        case 7:
                            System.Console.WriteLine("Terugkeren naar hoofdmenu.");
                            break;
                    }
                }
            }
            catch (BookNotFoundException bex)
            {
                System.Console.WriteLine(bex.Message);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Een onverwachte fout is opgetreden: {ex.Message}");
                Console.ReadKey();
            }
            finally
            {
                Console.Clear();
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
                        Console.ReadKey();
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
                        Console.ReadKey();
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
                        Console.ReadKey();
                    }
                    break;
            }
            Console.Clear();
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
                        Console.ReadKey();
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
                        Console.ReadKey();
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
                        Console.ReadKey();
                    }
                    break;
            }
            Console.Clear();
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
                    myLibrary.RemoveBookOnIsbn(isbnSearch);
                    break;
                case 2:
                    System.Console.WriteLine("Geef de titel van het boek in:");
                    string searchTitle = Console.ReadLine();
                    myLibrary.RemoveBookOnTitle(searchTitle);
                    break;
                case 3:
                    System.Console.WriteLine("Geef de auteur van het boek in:");
                    string searchAuthor = Console.ReadLine();
                    myLibrary.RemoveBookOnAuthor(searchAuthor);
                    break;
            }
            Console.Clear();

        }

        static void BorrowBook()
        {
            System.Console.WriteLine("Welke Boek zou je willen lenen?");
            myLibrary.ShowAllBooksTitles();
            string title = System.Console.ReadLine();

            // Zoek het boek op titel
            Book bookToBorrow = myLibrary.SearchBookByTitle(title);

            if (bookToBorrow != null && bookToBorrow.IsAvailable)
            {
                bookToBorrow.Borrow();
                Console.ReadKey();
            }
            else
            {
                System.Console.WriteLine("Boek is niet beschikbaar of bestaat niet.");
                Console.ReadKey();
            }
            Console.Clear();
        }
        static void ReturnBook()
        {
            System.Console.WriteLine("Welk boek wil je terugbrengen?");
            myLibrary.ShowBorrowedBooks();

            System.Console.WriteLine("Voer de titel van het boek in dat je wilt terugbrengen:");
            string title = System.Console.ReadLine();

            // Zoek het boek op titel
            Book bookToReturn = myLibrary.SearchBookByTitle(title);

            if (bookToReturn != null && !bookToReturn.IsAvailable) // Controleer of het boek uitgeleend is
            {
                bookToReturn.Return();
                Console.ReadKey();
            }
            else
            {
                System.Console.WriteLine("Dit boek is niet uitgeleend of bestaat niet in onze bibliotheek.");
                Console.ReadKey();
            }
            Console.Clear();
        }
    }
}

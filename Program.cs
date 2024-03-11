// Purpose: Main program file for the Library project.


namespace Library
{
    public class Program
    {
        private static Book newBook;

        static void Main()
        {

            Library myLibrary = new("My Library");


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
                        System.Console.WriteLine("Voeg een boek toe aan de bibliotheek");
                        System.Console.WriteLine("Geef de titel van het boek in:");
                        string title = Console.ReadLine();
                        System.Console.WriteLine("Geef de auteur van het boek in:");
                        string author = Console.ReadLine();
                        newBook = new Book(title, author, myLibrary);
                        myLibrary.AddBook(newBook);
                        break;
                    case 2:
                        System.Console.WriteLine("Geef de titel van het boek in:");
                        string titleInfo = Console.ReadLine();
                        Book bookInfo = myLibrary.Books.Find(book => book.Title == titleInfo);
                        if (bookInfo != null)
                        {
                            System.Console.WriteLine("Geef het publicatie jaar van het boek in:");
                            int publicationYear = int.Parse(Console.ReadLine());
                            bookInfo.PublicationYear = publicationYear;
                            System.Console.WriteLine("Geef het aantal paginas van het boek in:");
                            int pageCount = int.Parse(Console.ReadLine());
                            bookInfo.PageCount = pageCount;
                            System.Console.WriteLine("Geef de taal van het boek in:");
                            string language = Console.ReadLine();
                            bookInfo.Language = language;
                            System.Console.WriteLine("Geef de uitgever van het boek in:");
                            string publisher = Console.ReadLine();
                            bookInfo.Publisher = publisher;
                        }
                        else
                        {
                            System.Console.WriteLine("Boek niet gevonden!");
                        }
                        break;
                    case 3:
                        System.Console.WriteLine("Geef de titel van het boek in:");
                        string titleShow = Console.ReadLine();
                        Book bookShow = myLibrary.Books.Find(book => book.Title == titleShow);
                        if (bookShow != null)
                        {
                            bookShow.ShowInfo();
                        }
                        else
                        {
                            System.Console.WriteLine("Boek niet gevonden!");
                        }
                        break;
                    case 4:
                        System.Console.WriteLine("Geef de titel van het boek in:");
                        string titleSearch = Console.ReadLine();
                        System.Console.WriteLine("Geef de auteur van het boek in:");
                        string authorSearch = Console.ReadLine();
                        Book bookSearch = myLibrary.SearchBookByTitleAuthor(titleSearch, authorSearch);
                        if (bookSearch != null)
                        {
                            bookSearch.ShowInfo();
                        }
                        else
                        {
                            System.Console.WriteLine("Boek niet gevonden!");
                        }
                        break;
                    case 5:
                        System.Console.WriteLine("Geef de ISBN van het boek in:");
                        string isbn = Console.ReadLine();
                        myLibrary.RemoveBook(isbn);
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


    }
}

// Purpose: Represents a library.
using System.Globalization;

namespace bib_JesusOBulan
{
    /// Represents a library.
    public class Library
    {
        ///Properties
        private string name;

        // Gets or sets the name of the library.
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private List<Book> books = new List<Book>();


        // Gets or sets the list of books in the library.
        public List<Book> Books
        {
            get { return books; }
            private set { books = value; } //private set so that the list of books can only be modified from within the class
        }

        private readonly Dictionary<DateTime, ReadingRoomItem> allReadingRoomItems = new Dictionary<DateTime, ReadingRoomItem>();
        public Dictionary<DateTime, ReadingRoomItem> AllReadingRoomItems
        {
            get { return allReadingRoomItems.ToDictionary(); }
        }



        ///Constructor

        // Initializes a new instance of the Library class with the specified name.
        // <param name="name">The name of the library.</param>
        public Library(string name)
        {
            Name = name;
        }

        ///Methods
        public void AddBook(Book book)
        {
            // Add the new book to the collection
            Books.Add(book);
            book.Library = this;


        }

        // Removes a book from the library based on its ISBN number.
        public Book RemoveBookOnIsbn(string isbn)
        {

            Book book = Books.Find(book => book.IsbnNumber == isbn);
            if (book != null)
            {
                Books.Remove(book);
                System.Console.WriteLine("Boek verwijderd!");
            }
            else
            {
                System.Console.WriteLine("Boek niet gevonden!");
            }
            return book;
        }

        public Book RemoveBookOnTitle(string title)
        {

            Book book = Books.Find(book => book.Title == title);
            if (book != null)
            {
                Books.Remove(book);
                System.Console.WriteLine("Boek verwijderd!");
            }
            else
            {
                System.Console.WriteLine("Boek niet gevonden!");
            }
            return book;
        }

        public Book RemoveBookOnAuthor(string author)
        {

            Book book = Books.Find(book => book.Author == author);
            if (book != null)
            {
                Books.Remove(book);
                System.Console.WriteLine("Boek verwijderd!");
            }
            else
            {
                System.Console.WriteLine("Boek niet gevonden!");
            }
            return book;
        }


        public void ShowAllBooks()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("De Bibliotheek is leeg.");
            }
            else
            {
                foreach (var book in books)
                {
                    book.ShowInfo();
                }
            }

        }

        /// Searches for a book by its title and author.
        /// <param name="Title">The title of the book.</param>
        /// <param name="Author">The author of the book.</param>
        public Book SearchBookByTitleAuthor(string Title, string Author)
        {
            Book searchByTitleAuthor = books.Find(book => book.Title == Title && book.Author == Author);

            return searchByTitleAuthor;
        }

        public Book SearchBookByTitle(string title)
        {
            Book searchByTitle = books.Find(book => book.Title == title);

            return searchByTitle;
        }



        /// Searches for a book in the library by its ISBN number.
        /// <param name="ISBN">The ISBN number of the book to search for.</param>
        public Book SearchBookByISBN(string ISBN)
        {
            // Attempt to find a book with the specified ISBN
            Book searchBookByISBN = books.Find(book => book.IsbnNumber == ISBN);

            // Return the found book (or null if no book was found)
            return searchBookByISBN;
        }


        /// Searches for books by the specified author and displays the information of the found book.
        /// <param name="author">The author to search for.</param>
        public Book SearchBooksByAuthor(string author)
        {
            Book searchBookByAuthor = books.Find(book => book.Author == author);

            return searchBookByAuthor;
        }


        public Book SearchBooksByPublisher(string publisher)
        {
            Book searchBooksByPublisher = (Book)books.Where(book => book.Publisher == publisher);

            return searchBooksByPublisher;
        }

        public void AddNewspaper()
        {
            System.Console.WriteLine("Wat is de naam van de krant?");
            string title = Console.ReadLine();
            System.Console.WriteLine("Wat is de datum van de krant?");
            DateTime date = DateTime.Parse(Console.ReadLine());
            System.Console.WriteLine("Wat is de uitgeverij van de krant?");
            string publisher = Console.ReadLine();
            NewsPaper newsPaper = new NewsPaper(title, publisher, date);

            DateTime creationTime = DateTime.Now;

            AllReadingRoomItems.Add(creationTime, newsPaper);

            System.Console.WriteLine("Krant succesvol toegevoegd aan de leeszaal.");
        }

        public void AddMagazine()
        {
            System.Console.WriteLine("Wat is de naam van het maandblad?");
            string title = Console.ReadLine();
            System.Console.WriteLine("Wat is de maand van het maandblad?");
            byte month = byte.Parse(Console.ReadLine());
            System.Console.WriteLine("Wat is het jaar van het maandblad?");
            uint year = uint.Parse(Console.ReadLine());
            System.Console.WriteLine("Wat is de uitgeverij van het maandblad?");
            string publisher = Console.ReadLine();
            Magazine magazine = new Magazine(title, publisher, month, year);
            DateTime creationTime = DateTime.Now;

            AllReadingRoomItems.Add(creationTime, magazine);

            System.Console.WriteLine("Maandblad succesvol toegevoegd aan de leeszaal.");
        }


        public void ShowAllMagazines()
        {
            System.Console.WriteLine("Alle maandbladen uit de leeszaal:");
            foreach (var item in allReadingRoomItems.Values)
            {
                if (item is Magazine magazine)
                {
                    System.Console.WriteLine($"- {magazine.Title} van {magazine.Month}/{magazine.Year} van uitgeverij {magazine.Publisher}\n");
                }
            }
        }

        public void ShowAllNewspapers()
        {
            System.Console.WriteLine("Alle kranten uit de leeszaal:");
            foreach (var item in allReadingRoomItems.Values)
            {
                if (item is NewsPaper newspaper) // Pattern matching om te controleren of het item een NewsPaper is
                {
                    // De variabele 'newspaper' wordt hier gebruikt en zou in deze context bekend moeten zijn
                    string formattedDate = newspaper.Date.ToString("dddd d MMMM yyyy", new CultureInfo("nl-NL"));
                    System.Console.WriteLine($"- {newspaper.Title} van {formattedDate} van uitgeverij {newspaper.Publisher}\n");
                }
            }
        }


        public void AcquisitionsReadingRoomToday()
        {
            System.Console.WriteLine($"Aanwisten in de leeszaal van {DateTime.Now}\n");
            foreach (var item in allReadingRoomItems.Values)
            {
                System.Console.WriteLine($"{item.Title} met id {item.Identification}");
            }


        }


    }

}






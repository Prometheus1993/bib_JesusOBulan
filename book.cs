// Purpose: Contains the Book class and its properties, constructors, and methods.
namespace Library
{
    public class Book
    {
        /// Properties
        private string isbnNumber;
        public string IsbnNumber
        {
            get { return isbnNumber; }
            set
            {
                if (value.All(char.IsDigit) == true && value?.Length == 13)
                {
                    isbnNumber = value;
                }
                else
                {
                    System.Console.WriteLine("ISBN nummer moet 13 cijfers lang zijn.");
                }
            }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    System.Console.WriteLine("Titel mag niet leeg zijn.");
                }
                title = value;
            }
        }

        private string author;
        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        private Genre genre;
        public Genre GenreBook
        {
            get { return genre; }
            set { genre = value; }
        }

        private int publicationYear;
        public int PublicationYear
        {
            get { return publicationYear; }
            set
            {
                if (value <= DateTime.Now.Year)
                {
                    publicationYear = value;
                }
                else
                {
                    System.Console.WriteLine("Publicatie jaar kan niet in de toekomst zijn.");
                }
            }
        }

        private int pageCount;
        public int PageCount
        {
            get { return pageCount; }
            set
            {
                if (value <= 0)
                {
                    System.Console.WriteLine("Paginas kunnen niet 0 of minder zijn.");
                }
                else
                {
                    pageCount = value;
                }
            }
        }

        private string language;
        public string Language
        {
            get { return language; }
            set { language = value; }
        }

        private string publisher;
        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }

        private Library library;// The library that the book is associated with

        public Library Library 
        {
            get { return library; }
            set { library = value; }
        }

        /// Constructors

        public Book(string title, string author, Library library)
        {
            Title = title; // Set the book's title
            Author = author; // Set the book's author
            Library = library; // Set the book's library

        }



        public void ShowInfo()
        {
            // Print the title of the book
            System.Console.WriteLine($"Titel: {Title}");

            // Print the author of the book
            System.Console.WriteLine($"Auteur: {Author}");

            // Print the genre of the book
            System.Console.WriteLine($"Genre: {GenreBook}");

            // Print the publication year of the book
            System.Console.WriteLine($"Publicatie jaar: {PublicationYear}");

            // Print the publisher of the book
            System.Console.WriteLine($"Uitgeverij: {Publisher}");

            // Print the language of the book
            System.Console.WriteLine($"Taal: {Language}");

            // Print the page count of the book
            System.Console.WriteLine($"Paginas: {PageCount}");

            // Print the ISBN number of the book
            System.Console.WriteLine($"ISBN: {IsbnNumber}");

            // Print the library associated with the book (if applicable)
            System.Console.WriteLine($"Bibliotheek: {Library.Name}");

        }

        // Deserialize from CSV
        /// <summary>
        /// Deserializes a list of books from a CSV file.
        /// </summary>
        /// <param name="csvFile">The path to the CSV file.</param>
        /// <param name="library">The library to associate the books with.</param>
        public static List<Book> DeserializeFromCSV(string csvFile, Library library)
        {
            var books = new List<Book>();

            // Simplified CSV reading logic (assuming CSV format: Title,Author)
            var lines = File.ReadAllLines(csvFile).Skip(1); // Skip header
            foreach (var line in lines)
            {
                var columns = line.Split(','); // Simple CSV parsing, might need adjustment for complex scenarios
                if (columns.Length >= 2) // Basic validation
                {
                    string title = columns[0];
                    string author = columns[1];
                    // Create a new Book instance and associate it with the provided library
                    books.Add(new Book(title, author, library));
                }
            }

            return books;
        }


      

    }
}





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
                    System.Console.WriteLine("ISBN-Number should only contain numeric characters and have a length of 13.");
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
                    System.Console.WriteLine("The title cannot be empty");
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

        private Genre? genre;
        public Genre? GenreBook
        {
            get { return genre; }
            set { genre = value; }
        }

        private int? publicationYear;
        public int? PublicationYear
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
                    System.Console.WriteLine("The publication year must be in the past.");
                }
            }
        }

        private int? pageCount;
        public int? PageCount
        {
            get { return pageCount; }
            set
            {
                if (value <= 0)
                {
                    System.Console.WriteLine("Page Count cannot be 0 or negative");
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

        private Library library;

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


        /// <summary>
        /// Displays the book information on the console.
        /// </summary>
        public void ShowInfo()
        {
            // Print the title of the book
            System.Console.WriteLine($"Title: {Title}");

            // Print the author of the book
            System.Console.WriteLine($"Author: {Author}");

            // Print the genre of the book
            System.Console.WriteLine($"Genre: {GenreBook}");

            // Print the publication year of the book
            System.Console.WriteLine($"Publication Year: {PublicationYear}");

            // Print the publisher of the book
            System.Console.WriteLine($"Publisher: {Publisher}");

            // Print the language of the book
            System.Console.WriteLine($"Language: {Language}");

            // Print the page count of the book
            System.Console.WriteLine($"Page Count: {PageCount}");

            // Print the ISBN number of the book
            System.Console.WriteLine($"ISBN: {IsbnNumber}");

            // Print the library associated with the book (if applicable)
            System.Console.WriteLine($"Library: {Library?.Name ?? "Unknown"}\n");

        }


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


        //Genres
        public enum Genre
        {
            Fiction,
            NonFiction,

        }
    }
}





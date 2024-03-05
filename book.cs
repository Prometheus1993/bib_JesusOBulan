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

        public Book(string title, string author, Genre genre, int publicationYear, string publisher, string language, int pageCount, string isbnNumber)
        {
            Title = title;
            Author = author;
            GenreBook = genre;
            PublicationYear = publicationYear;
            Publisher = publisher;
            Language = language;
            PageCount = pageCount;
            IsbnNumber = isbnNumber;
        }

        public void AddInfo()
        {
            System.Console.WriteLine("what information would you like to add?");
            System.Console.WriteLine("1. Title");
            System.Console.WriteLine("2. Author");
            System.Console.WriteLine("3. Genre");
            System.Console.WriteLine("4. Publication Year");
            System.Console.WriteLine("5. Publisher");
            System.Console.WriteLine("6. Language");
            System.Console.WriteLine("7. Page Count");
            System.Console.WriteLine("8. ISBN");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    System.Console.WriteLine("Enter the title of the book: ");
                    Title = Console.ReadLine();
                    break;
                case 2:
                    System.Console.WriteLine("Enter the author of the book: ");
                    Author = Console.ReadLine();
                    break;
                case 3:
                    System.Console.WriteLine("Enter the genre of the book: ");
                    GenreBook = (Genre)Enum.Parse(typeof(Genre), Console.ReadLine(), true);
                    break;
                case 4:
                    System.Console.WriteLine("Enter the publication year of the book: ");
                    PublicationYear = int.Parse(Console.ReadLine());
                    break;
                case 5:
                    System.Console.WriteLine("Enter the publisher of the book: ");
                    Publisher = Console.ReadLine();
                    break;
                case 6:
                    System.Console.WriteLine("Enter the language of the book: ");
                    Language = Console.ReadLine();
                    break;
                case 7:
                    System.Console.WriteLine("Enter the page count of the book: ");
                    PageCount = int.Parse(Console.ReadLine());
                    break;
                case 8:
                    System.Console.WriteLine("Enter the ISBN of the book: ");
                    IsbnNumber = Console.ReadLine();
                    break;
                default:
                    System.Console.WriteLine("Invalid choice. Please enter a number between 1 and 8.");
                    break;

            }


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

        /// <summary>
        /// Loads a list of books from a CSV file.
        /// </summary>
        /// <param name="filePath">The file path of the CSV to load books from.</param>
        /// <returns>A list of Book objects loaded from the CSV file.</returns>
        public static List<Book> DeserializeFromCSV(string filePath)
        {
            List<Book> books = new List<Book>();

            string[] lines = File.ReadAllLines(filePath);

            // Skip the first line assuming it's a header and parse each line
            foreach (string line in lines.Skip(1))
            {
                // Split the line into fields
                string[] fields = line.Split(',');
                // Create a new Book object from the fields and add it to the list
                Book book = new(
                    fields[0], // title
                    fields[1], // author
                    (Genre)Enum.Parse(typeof(Genre), fields[2], true), // genre, case-insensitive parsing
                    int.Parse(fields[3]), // publication year
                    fields[4], // publisher
                    fields[5], // language
                    int.Parse(fields[6]), // page count
                    fields[7]); // ISBN number;

                books.Add(book);
            }

            return books;
        }


        //Genres
        public enum Genre
        {
            Fiction,
            NonFiction,
            Science,
            History,
            Fantasy,
            Biography,
            Mystery,
            Thriller,
            Romance,
            YoungAdult,
            Children,
            ScienceFiction,
            Horror,
            SelfHelp,
            Health,
            Travel,
            Art,
            Cookbook,
            Religion,
            Poetry,
            Journal,
            Business,
            Technology,
            MagicalRealism,
            HistoricalFiction
        }
    }
}





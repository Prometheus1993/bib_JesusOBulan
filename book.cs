// Purpose: Contains the Book class and its properties, constructors, and methods.
namespace bib_JesusOBulan
{
    public class Book : ILendable
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
                    throw new InvalidBookPropertyException("ISBN nummer moet 13 cijfers bevatten.");
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
                    throw new InvalidBookPropertyException("Titel mag niet leeg zijn.");
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

        // Gebruik een private field voor GenreBook met een public property die BorrowDays update.
        private Genre genreBook;
        public Genre GenreBook
        {
            get { return genreBook; }
            set
            {
                genreBook = value;
                UpdateBorrowDays(); // Update BorrowDays elke keer dat het genre verandert
            }
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

                    throw new InvalidBookPropertyException("Publicatie jaar mag niet in de toekomst liggen.");
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
                    throw new InvalidBookPropertyException("Pagina's moet groter zijn dan 0.");
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

        public string BookTitle { get; }

        /// interface Ilendable

        public bool IsAvailable { get; set; }
        public DateTime BorrowingDate { get; set; }
        private int borrowDays;
        public int BorrowDays
        {
            get { return borrowDays; }
            set { SetBorrowDays(value); }
        }


        /// Constructors

        public Book(string title, string author, Library library, Genre genreBook)
        {
            Title = title; // Set the book's title
            Author = author; // Set the book's author
            Library = library; // Set the book's library
            GenreBook = genreBook; // Set the book's genre
            this.IsAvailable = true;
            if (GenreBook == Genre.Schoolboek)
            {
                this.BorrowDays = 10;
            }
            else
            {
                this.BorrowDays = 20;
            }

        }

        public Book(string bookTitle)
        {
            BookTitle = bookTitle;
        }

        public void Borrow()
        {
            if (IsAvailable)
            {
                IsAvailable = false;
                BorrowingDate = DateTime.Now;
                DateTime dueDate = BorrowingDate.AddDays(BorrowDays);
                Console.WriteLine($"Boek '{Title}' is uitgeleend. Het moet teruggebracht worden op {dueDate.ToShortDateString()}.");
            }
            else
            {
                Console.WriteLine($"Het boek '{Title}' is momenteel niet beschikbaar voor uitlening.");
            }
        }

        public void Return()
        {
            IsAvailable = true;
            Console.WriteLine($"Het boek '{Title}' is teruggebracht. Dank u!");
        }

        public void ShowInfo()
        {
            if (IsAvailable)
            {
                Console.WriteLine($"Titel: {Title}");
                Console.WriteLine($"Auteur: {Author}");
                Console.WriteLine($"Genre: {GenreBook}");
                Console.WriteLine($"Publicatie jaar: {PublicationYear}");
                Console.WriteLine($"Uitgeverij: {Publisher}");
                Console.WriteLine($"Taal: {Language}");
                Console.WriteLine($"Paginas: {PageCount}");
                Console.WriteLine($"ISBN: {IsbnNumber}\n");
                Console.ReadKey();
            }
            else
            {
                System.Console.WriteLine("Het boek is niet beschikbaar.");
                Console.ReadKey();
            }
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
                    books.Add(new Book(title, author, library, Genre.Fiction));
                }
            }

            return books;
        }

        private void UpdateBorrowDays()
        {
            if (GenreBook == Genre.Schoolboek)
            {
                BorrowDays = 10;
            }
            else
            {
                BorrowDays = 20;
            }
        }

        private void SetBorrowDays(int days)
        {
            borrowDays = days;
        }
    }
}





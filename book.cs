using System;


/// Represents a book.

public class Book
{
    /// Properties


    // Gets or sets the ISBN number of the book.
    private string isbnNumber;
    public string IsbnNumber
    {
        get { return isbnNumber; }
        set
        {
            if (value?.All(char.IsDigit) == true && value?.Length == 13)
            {
                isbnNumber = value;
            }
            else
            {
                throw new ArgumentException("ISBN-Number should only contain numeric characters and have a length of 13.");
            }
        }
    }


    // Gets or sets the title of the book.
    private string title;
    public string Title
    {
        get { return title; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("The title cannot be empty");
            }
            title = value;
        }
    }


    // Gets or sets the author of the book.
    private string author;
    public string Author
    {
        get { return author; }
        set { author = value; }
    }


    // Gets or sets the genre of the book.
    private Genre genre;
    public Genre GenreBook
    {
        get { return genre; }
        set { genre = value; }
    }


    // Gets or sets the publication year of the book.
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
                throw new ArgumentException("The publication year must be in the past.");
            }
        }
    }


    // Gets or sets the page count of the book.
    private int pageCount;
    public int PageCount
    {
        get { return pageCount; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Page Count cannot be 0 or negative");
            }
            else
            {
                pageCount = value;
            }
        }
    }


    // Gets or sets the language of the book.
    private string language;
    public string Language
    {
        get { return language; }
        set { language = value; }
    }


    // Gets or sets the publisher of the book.
    private string publisher;
    public string Publisher
    {
        get { return publisher; }
        set { publisher = value; }
    }

    private Library library;

    // Allows external access to the library field with get and set methods
    public Library Library
    {
        get { return library; }
        set { library = value; }
    }

    /// Constructors

    // Constructor for the Book class
    // Initializes a new instance of the Book class with specified title, author, and library
    public Book(string title, string author, Library library)
    {
        Title = title; // Set the book's title
        Author = author; // Set the book's author
        Library = library; // Associate the book with a specific library
    }

    //Constructor for the CSV File
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
    System.Console.WriteLine($"Library: {Library.Name}");
}

/// <summary>
/// Loads a list of books from a CSV file.
/// </summary>
/// <param name="filePath">The file path of the CSV to load books from.</param>
/// <returns>A list of Book objects loaded from the CSV file.</returns>
public static List<Book> LoadBooksFromCsv(string filePath)
{
    List<Book> books = new List<Book>();
    // Read all lines from the CSV file
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





using System;



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
        private set { books = value; } //Controle!!!
    }

    ///Constructor

    // Initializes a new instance of the Library class with the specified name.
    // <param name="name">The name of the library.</param>
    public Library(string name)
    {
        Name = name;
    }

    ///Methods

    /// Adds a book to the library.
    /// <param name="book">The book to be added.</param>
    public void AddBook(Book book)
    {
        books.Add(book);
    }


    /// Removes a book from the library based on its ISBN number.
    /// <param name="IsbnNumber">The ISBN number of the book to be removed.</param>
    public void RemoveBook(string ISBN)
    {

        Book bookToRemove = books.Find(book => book.IsbnNumber == ISBN);

        if (bookToRemove == null)
        {
            System.Console.WriteLine("Book not found");
        }
        else
        {
            System.Console.WriteLine("Book found:");
            books.Remove(bookToRemove);
        }
    }


    /// Searches for a book by its title and author.
    /// <param name="Title">The title of the book.</param>
    /// <param name="Author">The author of the book.</param>
    public void SearchBookByTitleAuthor(string Title, string Author)
    {
        Book searchByTitleAuthor = books.Find(book => book.Title == Title && book.Author == Author);

        if (searchByTitleAuthor != null)
        {
            System.Console.WriteLine("Book found:");
            searchByTitleAuthor.ShowInfo();
        }
        else
        {
            System.Console.WriteLine("Book not found!");
        }
    }


    /// Searches for a book in the library by its ISBN number.
    /// <param name="ISBN">The ISBN number of the book to search for.</param>
    public void SearchBookByISBN(string ISBN)
    {
        Book searchBookByIsbn = books.Find(book => book.IsbnNumber == ISBN);

        if (searchBookByIsbn != null)
        {
            System.Console.WriteLine("Book found:");
            searchBookByIsbn.ShowInfo();
        }
        else
        {
            System.Console.WriteLine("book not found");
        }
    }


    /// Searches for books by the specified author and displays the information of the found book.
    /// <param name="author">The author to search for.</param>
    public void SearchBooksByAuthor(string author)
    {
        Book searchBookByAuthor = books.Find(book => book.Author == author);

        if (searchBookByAuthor != null)
        {
            System.Console.WriteLine("Book found:");
            searchBookByAuthor.ShowInfo();
        }
        else
        {
            System.Console.WriteLine("book not found");
        }
    }

    public void SearchBooksByPublisher(string publisher)
    {
        Book searchBooksByPublisher = (Book)books.Where(book => book.Publisher == publisher);

        if (searchBooksByPublisher != null)
        {
            System.Console.WriteLine("Book(s) found:");
            searchBooksByPublisher.ShowInfo();
        }
        else
        {
            System.Console.WriteLine("book(s) not found");
        }
    }
}




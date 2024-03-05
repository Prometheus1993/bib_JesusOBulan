// Purpose: This file contains the AddBook class. This class is responsible for adding a book to the library.
namespace Library
{
    public class AddBook()
    {
        private readonly Library myLibrary;

        public AddBook(Library library) : this()
        {
            myLibrary = library;
        }

        public void AddBookToLibrary()
        {
            System.Console.WriteLine("Enter the title of the book: ");
            string title = Console.ReadLine();
            System.Console.WriteLine("Enter the author of the book: ");
            string author = Console.ReadLine();
            if (myLibrary.Books.Exists(book => book.Title == title))
            {
                System.Console.WriteLine("Book already exists in the library.");
                System.Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            Book newBook = new(title, author, myLibrary);
            myLibrary.AddBook(newBook);
            Console.WriteLine("Book added successfully.");
            System.Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
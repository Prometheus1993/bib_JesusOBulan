// Purpose: Main program file for the Library project.
using static Library.Book;

namespace Library
{
    public class Program
    {
        static void Main()
        {

            Library myLibrary = new("My Library");
           

            string filePath = "csv/books.csv";

            List<Book> booksFromCsv = Book.DeserializeFromCSV(filePath);

            foreach (var book in booksFromCsv)
            {
                myLibrary.AddBook(book);
            }

            while (true)
            {
                System.Console.WriteLine("1 - Add book to Library");
                System.Console.WriteLine("2 - Add info to a book");
                System.Console.WriteLine("3 - Show all information about a book");
                System.Console.WriteLine("4 - Search for a book");
                System.Console.WriteLine("5 - Remove a book from the library");
                System.Console.WriteLine("6 - Show all books in the library");
                System.Console.WriteLine("7 - Exit");

                if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 7)
                {
                    System.Console.WriteLine("Invalid choice. Please enter a number between 1 and 7.");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                Console.Clear();

                switch (choice)
                {
                    case 1:
                        myLibrary.AddBook(CreateBookFromUserInput());
                        break;
                    case 2:
                        System.Console.WriteLine("Enter the ISBN of the book you want to add info to: ");
                        string isbnToAddInfo = Console.ReadLine();
                        myLibrary.SearchBookByISBN(isbnToAddInfo).AddInfo();
                        break;
                    case 3:
                        System.Console.WriteLine("Enter the ISBN of the book you want to see info of: ");
                        string isbn = Console.ReadLine();
                        myLibrary.SearchBookByISBN(isbn).ShowInfo();
                        break;
                    case 4:
                        System.Console.WriteLine("Enter the Title of the book you want to search for: ");  
                        string title = Console.ReadLine();
                        var book = myLibrary.searchBookByTitle(title);
                        book.ShowInfo();
                        break;
                    case 5:
                        System.Console.WriteLine("Enter the ISBN of the book you want to remove: ");
                        string isbnToRemove = Console.ReadLine();
                        myLibrary.RemoveBook(isbnToRemove);
                        break;
                    case 6:
                        myLibrary.ShowAllBooks();
                        break;
                    case 7:
                        System.Console.WriteLine("Goodbye!");
                        Thread.Sleep(1000);
                        break;
                }
                if (choice == 7)
                {
                    break;
                }
            }

        }
        public static Book CreateBookFromUserInput()
        {
            System.Console.WriteLine("Enter the title of the book: ");
            string title = Console.ReadLine();
            System.Console.WriteLine("Enter the author of the book: ");
            string author = Console.ReadLine();
            System.Console.WriteLine("enter the library of the book: ");
            Library library = new(Console.ReadLine());
            Book book = new Book(title, author, library);
            Console.WriteLine("Book added successfully.");
            System.Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
            return book;

        }

    }
}

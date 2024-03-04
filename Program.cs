
// Purpose: Main program file for the Library project.
namespace Library
{
    public class Program
    {
        static void Main()
        {

            Library myLibrary = new("My Library");
            AddInfo addInfo = new(myLibrary);
            AddBook AddBook = new(myLibrary);
            ShowAllBookInfo showAllBookInfo = new(myLibrary);
            Searchbook searchBook = new(myLibrary);
            RemoveBook removeBook = new(myLibrary);
            ShowAllBooks showAllBooks = new(myLibrary);

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
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (choice)
                {
                    case 1:
                        AddBook.AddBookToLibrary();
                        break;
                    case 2:
                        addInfo.UpdateBookInfo();
                        break;
                    case 3:
                        showAllBookInfo.ShowAllBookInformation();
                        break;
                    case 4:
                        searchBook.SearchBookByTitle();
                        break;
                    case 5:
                        removeBook.RemoveBookFromLibrary();
                        break;
                    case 6:
                        showAllBooks.ShowAllBooksInLibrary();
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
    }
}

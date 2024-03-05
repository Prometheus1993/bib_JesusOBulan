// Purpose: Main program file for the Library project.


namespace Library
{
    public class Program
    {
        static void Main()
        {

            Library myLibrary = new("My Library");


            string filePath = "csv/books.csv";

            List<Book> booksFromCsv = Book.DeserializeFromCSV(filePath, myLibrary);

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

                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    case 5:

                        break;
                    case 6:

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

namespace Library
{
    public class RemoveBook()
    {
        private readonly Library myLibrary;

        public RemoveBook(Library library) : this()
        {
            myLibrary = library;
        }

        public void RemoveBookFromLibrary()
        {
            System.Console.WriteLine("Enter the title of the book you want to remove: ");
            string title = Console.ReadLine();
            Book book = myLibrary.Books.Find(book => book.Title == title);
            bool input = false;
            while (input == false)
            {
                if (book != null)
                {
                    myLibrary.Books.Remove(book);
                    System.Console.WriteLine("Book removed!");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                    input = true;
                }
                else
                {
                    Console.WriteLine("Book not found.");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                    input = true;
                }
            }
        }
    }
}
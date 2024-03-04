namespace Library
{
    public class ShowAllBookInfo(Library library)
    {
        private readonly Library myLibrary = library;

        public void ShowAllBookInformation()
        {
            Console.WriteLine("Enter the title of the book you want to see information about: ");
            string title = Console.ReadLine();
            Book book = myLibrary.Books.Find(book => book.Title == title);
            bool input = false;
            while (input == false)
            {
                if (book != null)
                {
                    book.ShowInfo();
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
namespace Library
{
    public class ShowAllBooks()
    {
        private readonly Library myLibrary;

        public ShowAllBooks(Library library) : this()
        {
            myLibrary = library;
        }

        public void ShowAllBooksInLibrary()
        {
            foreach (Book book in myLibrary.Books)
            {
                book.ShowInfo();
            }
            System.Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }
    }
    
}
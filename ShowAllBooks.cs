namespace Library
{
    public class ShowAllBooks(Library library)
    {
        private readonly Library myLibrary = library;

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
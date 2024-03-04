namespace Library{
    public class Searchbook(Library library){
        private readonly Library myLibrary = library;

        public void SearchBookByTitle(){
            System.Console.WriteLine("Enter the title of the book you want to search for: ");
            string title = Console.ReadLine();
            Book book = myLibrary.Books.Find(book => book.Title == title);
            bool input = false;
            while (input == false)
            {
                if (book != null)
                {
                    System.Console.WriteLine("Book found!");
                    System.Console.WriteLine($"Title: {book.Title}");
                    System.Console.WriteLine($"Author: {book.Author}");
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
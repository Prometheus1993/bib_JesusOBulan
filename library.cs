// Purpose: Represents a library.
namespace Library
{
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
            // Add the new book to the collection
            Books.Add(book);

        }

        public void AssignBookToLibrary(Book book)
        {
            book.Library = this;
        }


        /// Removes a book from the library based on its ISBN number.
        /// <param name="IsbnNumber">The ISBN number of the book to be removed.</param>
        public Book RemoveBook(string isbn)
        {
            // Find the book by ISBN
            Book book = Books.Find(book => book.IsbnNumber == isbn);

            if (book != null)
            {
                // Remove the book if found
                Books.Remove(book);
                System.Console.WriteLine("Book removed!");
            }
            else
            {
                System.Console.WriteLine("Book not found.");
            }

            // Return the removed book, or null if not found
            return book;
        }

        public void ShowAllBooks()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("The library is empty.");
            }
            else
            {
                foreach (var book in books)
                {
                    book.ShowInfo();
                }
            }

        }

        /// Searches for a book by its title and author.
        /// <param name="Title">The title of the book.</param>
        /// <param name="Author">The author of the book.</param>
        public Book SearchBookByTitleAuthor(string Title, string Author)
        {
            Book searchByTitleAuthor = books.Find(book => book.Title == Title && book.Author == Author);

            return searchByTitleAuthor;
        }

        public Book SearchBookByTitle(string title)
        {
            Book searchByTitle = books.Find(book => book.Title == title);

            return searchByTitle;
        }

        

        /// Searches for a book in the library by its ISBN number.
        /// <param name="ISBN">The ISBN number of the book to search for.</param>
        public Book SearchBookByISBN(string ISBN)
        {
            // Attempt to find a book with the specified ISBN
            Book searchBookByISBN = books.Find(book => book.IsbnNumber == ISBN);

            // Return the found book (or null if no book was found)
            return searchBookByISBN;
        }


        /// Searches for books by the specified author and displays the information of the found book.
        /// <param name="author">The author to search for.</param>
        public Book SearchBooksByAuthor(string author)
        {
            Book searchBookByAuthor = books.Find(book => book.Author == author);

            return searchBookByAuthor;
        }

        public Book SearchBooksByPublisher(string publisher)
        {
            Book searchBooksByPublisher = (Book)books.Where(book => book.Publisher == publisher);

            return searchBooksByPublisher;
        }


    }

}
    





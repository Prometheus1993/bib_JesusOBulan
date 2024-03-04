using static Library.Book;

// Purpose: Add information to a book in the library.
namespace Library
{
    public class AddInfo(Library library)
    {
        private readonly Library myLibrary = library;

        public void UpdateBookInfo()
        {
            System.Console.WriteLine("Enter the title of the book to update: ");
            string title = Console.ReadLine();
            Book bookToUpdate = myLibrary.Books.Find(book => book.Title == title);
            if (bookToUpdate != null)
            {
                while (true)
                {
                    System.Console.WriteLine("1 - Update genre");
                    System.Console.WriteLine("2 - Update publication year");
                    System.Console.WriteLine("3 - Update publisher");
                    System.Console.WriteLine("4 - Update language");
                    System.Console.WriteLine("5 - Update page count");
                    System.Console.WriteLine("6 - Update ISBN number");
                    System.Console.WriteLine("7 - Finish updating");

                    int updateChoice = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();


                    switch (updateChoice)
                    {
                        case 1:
                            System.Console.WriteLine("Enter the new genre of the book: ");
                            string newGenre = Console.ReadLine();
                            bookToUpdate.GenreBook = (Genre)Enum.Parse(typeof(Genre), newGenre, true);
                            break;
                        case 2:
                            System.Console.WriteLine("Enter the new publication year of the book: ");
                            bookToUpdate.PublicationYear = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 3:
                            System.Console.WriteLine("Enter the new publisher of the book: ");
                            bookToUpdate.Publisher = Console.ReadLine();
                            break;
                        case 4:
                            System.Console.WriteLine("Enter the new language of the book: ");
                            bookToUpdate.Language = Console.ReadLine();
                            break;
                        case 5:
                            System.Console.WriteLine("Enter the new page count of the book: ");
                            bookToUpdate.PageCount = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 6:
                            System.Console.WriteLine("Enter the new ISBN number of the book: ");
                            bookToUpdate.IsbnNumber = Console.ReadLine();
                            break;
                        case 7:
                            
                            return;
                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                    Console.WriteLine("Book information updated successfully.");

                }
            }
            else
            {
                Console.WriteLine("Book not found.");
            }

        }
    }
}


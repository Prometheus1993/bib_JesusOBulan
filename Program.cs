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
                System.Console.WriteLine("1 - Voeg een boek toe aan de bibliotheek");
                System.Console.WriteLine("2 - Voeg informatie toe aan een boek");
                System.Console.WriteLine("3 - Toon informatie over een boek");
                System.Console.WriteLine("4 - Zoek een boek in de bibliotheek");
                System.Console.WriteLine("5 - Verwijder een boek uit de bibliotheek");
                System.Console.WriteLine("6 - Toon alle boeken in de bibliotheek");
                System.Console.WriteLine("7 - Verlaat de bibliotheek");

                if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 7)
                {
                    System.Console.WriteLine("Ongeldige keuze! Probeer opnieuw.");
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
                        System.Console.WriteLine("Tot Ziens!");
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

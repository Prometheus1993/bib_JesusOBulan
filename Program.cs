using System;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
        List<Book> mybooks = Book.LoadBooksFromCsv("/Users/jesusobulan/Desktop/ap-hogeschool/semester-2/oop/projectOpdracht/bib_JesusOBulan/books.csv");
        foreach (Book book in mybooks)
        {
            book.ShowInfo();
            Console.WriteLine();
        }
    }
}

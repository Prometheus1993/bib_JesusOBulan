using System;

public class Library
{
    private string name;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private List<Book> books = new List<Book>();
    public List<Book> Books
    {
        get { return books; }
        set { books = value; }
    }

    public Library(string name)
    {
        Name = name;
    }
    
}
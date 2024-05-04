namespace bib_JesusOBulan;

public class BookNotFoundException : Exception
{
    public BookNotFoundException(string message) : base(message)
    {
    }
}

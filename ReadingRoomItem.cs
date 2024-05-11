namespace bib_JesusOBulan;

public abstract class ReadingRoomItem
{
    //PROPERTIES
    private string title;
    public string Title
    {
        get { return title; }

    }
    private string publisher;
    public string Publisher
    {
        get { return publisher; }
        set { publisher = value; }
    }

    //Nachecken
    private string identification;
    public abstract string Identification
    {
        get;
    }


    //nachecken
    private string categorie;
    public abstract string Categorie
    {
        get;

    }

    public ReadingRoomItem(string title, string publisher)
    {
        this.title = title;
        this.publisher = publisher;
    }







}

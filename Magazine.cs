namespace bib_JesusOBulan;

public class Magazine : ReadingRoomItem
{
    private byte month;
    public byte Month
    {
        get { return month; }
        set
        {
            if (value > 12)
            {
                System.Console.WriteLine("De maand is maximaal 12");
            }
            else
            {
                month = value;
            }
        }
    }

    private uint year;
    public uint Year
    {
        get { return year; }
        set
        {
            if (value > 2500)
            {
                System.Console.WriteLine("Het jaartal is maximaal 2500");
            }
            else
            {
                year = value;
            }
        }
    }

    //NAZIEN
    public override string Identification
    {
        get
        {
            string prefix;
            switch (Title)
            {
                case "National Geographic":
                    prefix = "NG";
                    break;
                case "Time":
                    prefix = "T";
                    break;
                case "Scientific American":
                    prefix = "SA";
                    break;
                case "New Scientist":
                    prefix = "NS";
                    break;
                default:
                    prefix = Title.Length > 2 ? Title.Substring(0, 2).ToUpper() : Title.ToUpper();
                    break;
            }

            return $"{prefix}{Month:00}{Year:0000}";
        }
    }

    public override string Categorie
    {
        get { return "Maandblad"; }
    }

    public Magazine(string title, string publisher, byte month, uint year) : base(title, publisher)
    {
        Month = month;
        Year = year;
    }


}

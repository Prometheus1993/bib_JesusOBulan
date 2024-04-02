namespace bib_JesusOBulan;

public class NewsPaper : ReadingRoomItem
{
    private DateTime date;
    public DateTime Date
    {
        get { return date; }
        set { date = value; }
    }

    //nazien
    public override string Identification
    {
        get
        {
            string prefix;
            switch (Title)
            {
                case "Gazet Van Antwerpen":
                    prefix = "GVA";
                    break;
                case "De Standaard":
                    prefix = "DS";
                    break;
                case "Het Laatste Nieuws":
                    prefix = "HLN";
                    break;
                case "De Morgen":
                    prefix = "DM";
                    break;
                default:
                    prefix = Title.Length > 2 ? Title.Substring(0, 2).ToUpper() : Title.ToUpper();
                    break;
            }

            return $"{prefix}{Date:ddMMyyyy}";
        }
    }

    //nazien
    public override string Categorie
    {
        get { return "krant"; }
    }

    public NewsPaper(string title, string publisher, DateTime date) : base(title, publisher)
    {
        Date = date;
    }

}

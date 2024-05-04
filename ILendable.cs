namespace bib_JesusOBulan;
internal interface ILendable
{
    bool IsAvailable { get; set; }
    DateTime BorrowingDate { get; set; }
    int BorrowDays { get; set; }
    void Borrow();
    void Return();
}

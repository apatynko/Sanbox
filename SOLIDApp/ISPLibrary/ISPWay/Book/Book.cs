using System;

namespace ISPLibrary.ISPWay
{
    public class Book : IBorrowableBook
    {
        public string Author { get; set; }
        public DateTime BorrowDate { get; set; }
        public string Borrower { get; set; }
        public int CheckOutDurationDays { get; set; } = 14;
        public string LibraryId { get; set; }
        public int Pages { get; set; }
        public string Title { get; set; }

        public void CheckIn()
        {
            Borrower = "";
        }
        public void CheckOut(string borrower)
        {
            Borrower = borrower;
            BorrowDate = DateTime.Now;
        }

        public DateTime GetDueDate()
        {
            return BorrowDate.AddDays(CheckOutDurationDays);
        }
    }
}

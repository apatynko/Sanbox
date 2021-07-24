using System;

namespace ISPLibrary.NormalWay
{
    class AudioBook : ILibraryItem
    {
        public string Author { get; set; }
        public DateTime BorrowDate { get; set; }
        public string Borrower { get; set; }
        public int CheckOutDurationDays { get; set; }
        public string LibraryId { get; set; }
        public int Pages { get; set; } = -1;
        public string Title { get; set; }

        public int RuntimeInMinutes { get; set; }
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
            throw new NotImplementedException();
        }
    }
}

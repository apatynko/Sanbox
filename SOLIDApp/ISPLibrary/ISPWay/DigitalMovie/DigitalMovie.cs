using System;
using System.Collections.Generic;
using System.Text;

namespace ISPLibrary.ISPWay
{
    public class DigitalMovie: IBorrowableDVD
    {
        public DateTime BorrowDate { get; set; }
        public string Borrower { get; set; }
        public int CheckOutDurationDays { get; set; } = 14;
        public string LibraryId { get; set; }
        public string Title { get; set; }
        public List<string> Actors { get; set; }
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

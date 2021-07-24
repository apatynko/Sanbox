using System;
using System.Collections.Generic;
using System.Text;

namespace ISPLibrary.NormalWay
{
    public class ReferenceBook: ILibraryItem
    {
        public string LibraryId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public int CheckOutDurationDays { get; set; } = 0;
        public string Borrower { get; set; }
        public DateTime BorrowDate { get; set; }
        public void CheckOut(string borrower)
        {
            throw new NotImplementedException();
        }
        public void CheckIn()
        {
            throw new NotImplementedException();
        }
        public DateTime GetDueDate()
        {
            throw new NotImplementedException();
        }
    }
}

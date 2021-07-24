using System;
using System.Collections.Generic;
using System.Text;

namespace ISPLibrary.NormalWay
{
    public interface ILibraryItem
    {
        string Author { get; set; }
        DateTime BorrowDate { get; set; }
        string Borrower { get; set; }
        int CheckOutDurationDays { get; set; }
        string LibraryId { get; set; }
        int Pages { get; set; }
        string Title { get; set; }
        void CheckOut(string borrower);
        void CheckIn();
        DateTime GetDueDate();

    }
}

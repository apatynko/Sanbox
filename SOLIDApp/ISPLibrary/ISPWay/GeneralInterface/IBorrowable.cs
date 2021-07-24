using System;
using System.Collections.Generic;
using System.Text;

namespace ISPLibrary.ISPWay
{
    public interface IBorrowable
    {
        DateTime BorrowDate { get; set; }
        string Borrower { get; set; }
        int CheckOutDurationDays { get; set; }
        void CheckOut(string borrower);
        void CheckIn();
        DateTime GetDueDate();
    }
}

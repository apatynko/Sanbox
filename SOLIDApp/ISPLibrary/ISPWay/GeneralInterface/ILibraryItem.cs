using System;
using System.Collections.Generic;
using System.Text;

namespace ISPLibrary.ISPWay
{
    public interface ILibraryItem
    {        
        string LibraryId { get; set; }
        string Title { get; set; }
    }
}

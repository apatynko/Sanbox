using System;
using System.Collections.Generic;
using System.Text;

namespace ISPLibrary.ISPWay
{
    public interface IDVD: ILibraryItem
    {
        List<string> Actors { get; set; }
        int RuntimeInMinutes { get; set; }
    }
}

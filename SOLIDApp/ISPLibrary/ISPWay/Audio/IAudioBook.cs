using System;
using System.Collections.Generic;
using System.Text;

namespace ISPLibrary.ISPWay
{
    public interface IAudioBook: ILibraryItem
    {
        int RuntimeInMinutes { get; set; }
    }
}

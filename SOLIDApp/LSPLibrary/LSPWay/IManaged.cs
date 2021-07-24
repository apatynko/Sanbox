using System;
using System.Collections.Generic;
using System.Text;

namespace LSPLibrary.LSPWay
{
    public interface IManaged: IEmployee 
    {
        IEmployee Manager { get; set; }
        void AssignManager(IEmployee manager);
    }
}

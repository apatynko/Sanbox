using System;
using System.Collections.Generic;
using System.Text;

namespace AutofacLibrary.DIPWay
{
    public class Application : IApplication
    {
        IBusinessLogic _bussinessLogic;
        public Application(IBusinessLogic businessLogic)
        {
            _bussinessLogic = businessLogic;
        }

        public void Run()
        {
            _bussinessLogic.ProcessData();
        }
    }
}

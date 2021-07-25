using AutofacLibrary.DIPWay.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutofacLibrary.DIPWay
{
    public class BetterBusinessLogic : IBusinessLogic
    {
        ILogger _logger;
        IDataAccess _dataAccess;
        public BetterBusinessLogic(ILogger logger, IDataAccess dataAccess)
        {
            _logger = logger;
            _dataAccess = dataAccess;
        }
        public void ProcessData()
        {

            _logger.Log("Starting the processing of data.");
            Console.WriteLine();

            Console.WriteLine("Processing the data");
            _dataAccess.SaveData("ProcessedInfo");
            _logger.Log("Finished processing of the data.");
            Console.WriteLine();
        }
    }
}

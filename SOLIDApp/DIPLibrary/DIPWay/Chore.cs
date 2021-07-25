using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPLibrary.DIPWay
{
    public class Chore : IChore
    {
        ILogger _logger;
        IMessageCenter _messageCenter;
        public string ChoreName { get; set; }
        public IPerson Owner { get; set; }
        public double HoursWorked { get; private set; }
        public bool IsComplete { get; private set; }
        public Chore(ILogger logger, IMessageCenter messageCenter)
        {
            _logger = logger;
            _messageCenter = messageCenter;
        }

        public void PerformedWork(double hours)
        {
            HoursWorked += hours;            
            _logger.Log($"Performed work on { ChoreName }");
        }

        public void CompleteChore()
        {
            IsComplete = true;

            _logger.Log($"Completed { ChoreName }");
            
            _messageCenter.SendMessage(Owner, $"The chore { ChoreName } is complete.");
        }
    }
}

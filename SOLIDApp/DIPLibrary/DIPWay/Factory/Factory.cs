using System;
using System.Collections.Generic;
using System.Text;

namespace DIPLibrary.DIPWay
{
    public static class Factory
    {
        public static IPerson CreatePerson()
        {
            return new Person();
        }

        public static IChore CreateChore()
        {
            return new Chore(CreateLogger(), CreateMessageCenter());
        }

        public static ILogger CreateLogger()
        {
            return new Logger();
        }

        public static IMessageCenter CreateMessageCenter()
        {
            return new Texter();
        }
    }
}

using System;

namespace Telephony.Exceptions
{
   public class InvalidNumberException:Exception
    {
        private const string EXC_MSG = "Invalid number!";

        public InvalidNumberException()
            :base(EXC_MSG)
        {
        }

        public InvalidNumberException(string message) 
            : base(message)
        {
        }

      
    }
}

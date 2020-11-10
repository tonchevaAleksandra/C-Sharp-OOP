using System;
using System.Collections.Generic;
using System.Text;

namespace CustomException.Exceptions
{
    public class InvalidPersonNameException : ApplicationException
    {
        public InvalidPersonNameException(string message) 
            : base(message)
        {
         
        }
    }
}

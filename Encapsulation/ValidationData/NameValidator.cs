using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class NameValidator
    {
        public static void ValidateName(string value)
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
            }
        }
    }
}

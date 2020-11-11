using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeAttributes
{
    //[Author]
    [AttributeUsage(AttributeTargets.Class| AttributeTargets.Enum|AttributeTargets.Interface, AllowMultiple =true)]
   public class AuthorAttribute:Attribute
    {
        public AuthorAttribute(string name)
        {
            this.Name = name;
        }
        public string Name { get; private set; }
    }
}

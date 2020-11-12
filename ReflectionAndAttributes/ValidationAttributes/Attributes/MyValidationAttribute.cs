using System;

namespace ValidationAttributes.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple =true)]
   public abstract class MyValidationAttribute:Attribute
    {
        public abstract bool IsValid(object obj);
    }
}

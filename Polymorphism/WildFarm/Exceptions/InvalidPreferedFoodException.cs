using System;


namespace WildFarm.Exceptions
{
    public class InvalidPreferedFoodException : Exception
    {

        public InvalidPreferedFoodException(string message) : base(message)
        {
        }
    }
}

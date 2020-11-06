using System.Linq;
using Telephony.Contracts;
using Telephony.Exceptions;

namespace Telephony.Models
{
    public class SmartPhone : ICallable, IBrowsable
    {
        public string Browse(string url)
        {
           if(url.Any(c=>char.IsDigit(c)))
            {
                throw new InvalidURLException();
            }
            return $"Browsing: {url}!";
        }

        public string Call(string number)
        {
            if (!number.All(c => char.IsDigit(c)))
            {
                throw new InvalidNumberException();
            }

            return $"Calling... {number}";
        }
    }
}

using System;
using System.Linq;
using Telephony.Contracts;
using Telephony.Exceptions;
using Telephony.Models;

namespace Telephony.Core
{
    public class Engine : IEngine
    {
        private StationaryPhone stationaryPhone;
        private SmartPhone smartPhone;
        public Engine()
        {
            this.stationaryPhone = new StationaryPhone();
            this.smartPhone = new SmartPhone();
        }
      
        public void Run()
        {
            string[] phoneNumbers = Console.ReadLine()
                .Split()
                .ToArray();
            string[] sites = Console.ReadLine()
                .Split()
                .ToArray();

            CallNumbers(phoneNumbers);
            BrowseSites(sites);
        }

        private void BrowseSites(string[] sites)
        {
            foreach (var site in sites)
            {
                try
                {
                    Console.WriteLine(smartPhone.Browse(site));
                }
                catch (InvalidURLException msg)
                {
                    Console.WriteLine(msg.Message);
                }
            }
        }

        private void CallNumbers(string[] phoneNumbers)
        {
            foreach (var number in phoneNumbers)
            {
                try
                {
                    if (number.Length == 7)
                    {
                        Console.WriteLine(stationaryPhone.Call(number));
                    }
                    else if (number.Length == 10)
                    {
                        Console.WriteLine(smartPhone.Call(number));
                    }
                    else
                    {
                        throw new InvalidNumberException();
                    }
                }
                catch (InvalidNumberException msg)
                {
                    Console.WriteLine(msg.Message);
                }
            }
        }
    }
}

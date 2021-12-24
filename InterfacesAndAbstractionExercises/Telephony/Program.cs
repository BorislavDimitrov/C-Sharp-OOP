using System;
using System.Collections.Generic;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> phoneNumbers = Console.ReadLine().Split(" " , StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> urls = Console.ReadLine().Split(" " , StringSplitOptions.RemoveEmptyEntries).ToList();

            StationaryPhone stationaryPhone = new StationaryPhone();
            Smartphone smartphone = new Smartphone();

            foreach (var phoneNumber in phoneNumbers)
            {              
                if (phoneNumber.All(char.IsDigit) == false || (phoneNumber.Length != 7 && phoneNumber.Length != 10))
                {
                    Console.WriteLine("Invalid number!");
                    continue;
                }

                if (phoneNumber.Length == 10)
                {
                    Console.WriteLine(smartphone.Calling(phoneNumber));
                }
                else if (phoneNumber.Length == 7)
                {
                    Console.WriteLine(stationaryPhone.Calling(phoneNumber));
                }
            }

            foreach (var url in urls)
            {
                if (url.Any(char.IsDigit) == true)
                {
                    Console.WriteLine("Invalid URL!");
                    continue;
                }

                Console.WriteLine(smartphone.Browsing(url));
            }
        }
    }
}

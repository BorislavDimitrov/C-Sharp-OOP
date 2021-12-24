using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone : IPhoneCalling, IWebBrowsing
    {
        public string Browsing(string url)
        {
            return $"Browsing: {url}!";
        }

        public string Calling(string phoneNumber)
        {
            return $"Calling... {phoneNumber}";
        }
    }
}

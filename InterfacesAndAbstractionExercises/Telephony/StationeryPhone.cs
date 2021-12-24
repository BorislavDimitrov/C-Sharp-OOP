using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : IPhoneCalling
    {
        public string Calling(string phoneNumber)
        {
            return $"Dialing... {phoneNumber}";
        }
    }
}

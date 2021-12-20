using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    class RandomList : List<string>
    {

        public string RandomString()
        {
            string result = string.Empty;
            Random rndm = new Random();
            int index = rndm.Next(this.Count);
            result = this[index];
            this.RemoveAt(index);
            return result;
        }
    }
}

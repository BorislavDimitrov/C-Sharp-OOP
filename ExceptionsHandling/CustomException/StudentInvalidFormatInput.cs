using System;
using System.Collections.Generic;
using System.Text;

namespace CustomException
{
    public class StudentInvalidFormatInput : Exception
    {
        public StudentInvalidFormatInput(string message) 
            : base(message)
        {
        }
    }
}

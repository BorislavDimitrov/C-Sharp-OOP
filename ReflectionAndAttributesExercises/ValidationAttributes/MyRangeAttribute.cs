using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValidationAttributes
{
    class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;
        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }
        public override bool isValid(object obj)
        {
            int integerToCheck = (int)obj;
            if (integerToCheck < minValue || integerToCheck > maxValue)
            {
                return false;
            }
            return true;
        }
    }
}

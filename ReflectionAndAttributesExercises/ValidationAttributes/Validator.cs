using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ValidationAttributes
{
    public class Validator
    {
        public static bool IsValid(object obj)
        {
            var properties = obj.GetType().GetProperties();

            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes()
                    .Where(x => x.GetType().IsSubclassOf(typeof(MyValidationAttribute)))
                    .ToArray();

                foreach (MyValidationAttribute attribute in attributes)
                {
                    bool isValid = attribute.isValid(property.GetValue(obj));
                    if (!isValid)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

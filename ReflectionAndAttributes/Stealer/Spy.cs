using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string nameOfClassToInvestigate, params string[] fieldNames)
        {
            StringBuilder sb = new StringBuilder();

            Type type = Type.GetType(nameOfClassToInvestigate);

            Object instance = Activator.CreateInstance(type, new object[] { });

            sb.AppendLine($"Class under investigation: {type.FullName}");

            FieldInfo[] fields = type.GetFields(
                  BindingFlags.Static 
                | BindingFlags.Public 
                | BindingFlags.NonPublic
                | BindingFlags.Instance);
            foreach (var field in fields.Where(x => fieldNames.Contains(x.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(instance)}");
            }

            return sb.ToString();
        }
    }
}

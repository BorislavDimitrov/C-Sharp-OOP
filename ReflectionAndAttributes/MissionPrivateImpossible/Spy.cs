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

        public string AnalyzeAccesModifiers(string className)
        {
            Type type = Type.GetType(className);
            Object instance = Activator.CreateInstance(type, new object[] { });
            FieldInfo[] fields = type.GetFields(
                  BindingFlags.Static
                | BindingFlags.Public
                | BindingFlags.Instance);
            MethodInfo[] publicMethods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            MethodInfo[] privateMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            StringBuilder sb = new StringBuilder();

            foreach (var field in fields)
            {
                if (!field.IsPrivate)
                {
                    sb.AppendLine($"{field.Name} must be private!");
                }
            }

            foreach (var method in publicMethods.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} must be private!");
            }

            foreach (var method in privateMethods.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} must be public!");
            }

            return sb.ToString();
        }

        public string RevealPrivateMethods(string className)
        {
            Type type = Type.GetType(className);
            MethodInfo[] privateMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"All private Methods of Class: {type.FullName}");
            sb.AppendLine($"Base Class: {type.BaseType.Name}");

            foreach (var method in privateMethods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString();
        }
    }
}

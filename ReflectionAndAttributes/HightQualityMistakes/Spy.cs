using System;
using System.Linq;
using System.Text;
using System.Reflection;

namespace HightQualityMistakes
{
    public class Spy
    {
        private const string NAMESPACE = "HightQualityMistakes";

        public string AnalyzeAcessModifiers(string className)
        {
            Type classType = GetClassType(className);

            FieldInfo[] classFields = classType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

            MethodInfo[] publicMethods = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance);

            MethodInfo[] nonpublicMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

           string result = AppendMessages(classFields, publicMethods, nonpublicMethods);


            return result;

        }

        private static string AppendMessages(FieldInfo[] classFields, MethodInfo[] publicMethods, MethodInfo[] nonpublicMethods)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var field in classFields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
            foreach (var nonpublicMethod in nonpublicMethods
                .Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{nonpublicMethod.Name} have to be public!");
            }
            foreach (var publicMethod in publicMethods
                .Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{publicMethod.Name} have to be private!");
            }
            return sb.ToString().Trim();
        }

        public string StealFieldInfo(string investigatedClassName, params string[] requestedFiels)
        {
            Type classType = GetClassType(investigatedClassName);

            FieldInfo[] classFields = GetClassFields(classType);
            object classInstance = CreateInstance(classType);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Class under investigation: {investigatedClassName}");

            foreach (var field in classFields
                .Where(f => requestedFiels.Contains(f.Name)))
            {
                var value = field.GetValue(classInstance);
                sb.AppendLine($"{field.Name}: {value}");
            }

            return sb.ToString().Trim();

        }

        private static object CreateInstance(Type classType)
        {
            return Activator.CreateInstance(classType, new object[] { });
        }

        private static FieldInfo[] GetClassFields(Type classType)
        {
            return classType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
        }

        private static Type GetClassType(string investigatedClassName)
        {
            return Type.GetType(NAMESPACE + "." + investigatedClassName);
        }
    }
}

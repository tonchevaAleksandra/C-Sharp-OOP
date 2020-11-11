using System;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Stealer
{
    public class Spy
    {
        private const string NAMESPACE = "Stealer";

        public string StealFieldInfo(string investigatedClassName, params string[] requestedFiels)
        {

            Type classType = Type.GetType(NAMESPACE+"."+ investigatedClassName);

            FieldInfo[] classFields = classType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);

            Object classInstance = Activator.CreateInstance(classType, new object[] { });

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Class under investigation: {investigatedClassName}");

            foreach (var field in classFields
                .Where(f=>requestedFiels.Contains(f.Name)))
            {
                var value = field.GetValue(classInstance);
                sb.AppendLine($"{field.Name}: {value}");
            }

            return sb.ToString().Trim();

        }
    }
}

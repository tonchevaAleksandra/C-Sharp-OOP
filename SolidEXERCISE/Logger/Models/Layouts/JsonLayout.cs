using System.Text;

using Logger.Models.Contracts;

namespace Logger.Models.Layouts
{
    public class JsonLayout : ILayout
    {
        public string Format => this.GetFormat();

        private string GetFormat()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("[")
                .AppendLine("\tdate: {0},")
                .AppendLine("\tmessage: {1},")
                .AppendLine("\tlevel: {2}")
                .AppendLine("]");

            return sb.ToString().TrimEnd();
        }
    }
}

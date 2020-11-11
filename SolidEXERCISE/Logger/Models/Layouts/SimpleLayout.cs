
using Logger.Models.Contracts;

namespace Logger.Models.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}

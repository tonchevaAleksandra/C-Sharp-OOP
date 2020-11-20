using System.Collections.Generic;

namespace Adapter
{
    public interface ITarget
    {
        List<string> GetEmployees();
    }
}
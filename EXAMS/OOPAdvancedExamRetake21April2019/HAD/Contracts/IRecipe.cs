using System.Collections.Generic;

namespace HAD.Contracts
{
    public interface IRecipe : IItem
    {
        IReadOnlyList<string> RequiredItems { get; }
    }
}
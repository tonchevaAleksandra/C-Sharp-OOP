using System.Collections.Generic;

namespace HAD.Contracts
{
    public interface IInventory
    {
        long TotalStrengthBonus { get; }

        long TotalAgilityBonus { get; }

        long TotalIntelligenceBonus { get; }

        long TotalHitPointsBonus { get; }
        
        long TotalDamageBonus { get; }

        IReadOnlyCollection<IItem> CommonItems { get; }

        void AddCommonItem(IItem item);

        void AddRecipeItem(IRecipe recipe);
    }
}
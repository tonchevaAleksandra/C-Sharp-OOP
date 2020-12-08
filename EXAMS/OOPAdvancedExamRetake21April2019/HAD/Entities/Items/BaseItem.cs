using System.Text;
using HAD.Contracts;

namespace HAD.Entities.Items
{
    public abstract class BaseItem : IItem
    {
        protected BaseItem(
            string name,
            long strengthBonus,
            long agilityBonus,
            long intelligenceBonus,
            long hitPointsBonus,
            long damageBonus)
        {
            this.Name = name;
            this.StrengthBonus = strengthBonus;
            this.AgilityBonus = agilityBonus;
            this.IntelligenceBonus = intelligenceBonus;
            this.HitPointsBonus = hitPointsBonus;
            this.DamageBonus = damageBonus;
        }

        public string Name { get; private set; }

        public long StrengthBonus { get; private set; }

        public long AgilityBonus { get; private set; }

        public long IntelligenceBonus { get; private set; }

        public long HitPointsBonus { get; private set; }

        public long DamageBonus { get; private set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"###+{this.StrengthBonus} Strength");
            result.AppendLine($"###+{this.AgilityBonus} Agility");
            result.AppendLine($"###+{this.IntelligenceBonus} Intelligence");
            result.AppendLine($"###+{this.HitPointsBonus} HitPoints");
            result.Append($"###+{this.DamageBonus} Damage");

            return result.ToString();
        }
    }
}
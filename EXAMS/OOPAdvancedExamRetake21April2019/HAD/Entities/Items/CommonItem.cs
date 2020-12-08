using System.Text;

namespace HAD.Entities.Items
{
    public class CommonItem : BaseItem
    {
        public CommonItem(
            string name,
            long strengthBonus,
            long agilityBonus,
            long intelligenceBonus,
            long hitPointsBonus,
            long damageBonus)
            : base(
                name,
                strengthBonus,
                agilityBonus,
                intelligenceBonus,
                hitPointsBonus,
                damageBonus)
        { }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"###Item: {this.Name}");
            sb.AppendLine(base.ToString());

            return sb.ToString();
        }
    }
}
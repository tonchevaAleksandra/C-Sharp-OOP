using System.Collections.Generic;
using System.Linq;
using System.Text;
using HAD.Contracts;
using HAD.Core.Factory;
using HAD.Core.Factory.Contracts;
using HAD.Entities.Heroes;
using HAD.Entities.Items;
using HAD.Utilities;

namespace HAD.Core
{
    public class HeroManager : IManager
    {
        private readonly IDictionary<string, IHero> heroes;
        private IHeroFactory heroFactory;

        public HeroManager()
        {
            this.heroes = new Dictionary<string, IHero>();
            this.heroFactory = new HeroFactory();
        }

        public string AddHero(IList<string> arguments)
        {
            string heroName = arguments[0];
            string heroTypeName = arguments[1];

            IHero hero = this.heroFactory.CreateHero(heroTypeName, heroName);

            this.heroes.Add(heroName, hero);

            string result = string.Format(Constants.HeroCreateMessage, hero.GetType().Name, hero.Name); ;
            return result;
        }

        public string AddItem(IList<string> arguments)
        {
            string itemName = arguments[0];
            string heroName = arguments[1];
            long strengthBonus = long.Parse(arguments[2]);
            long agilityBonus = long.Parse(arguments[3]);
            long intelligenceBonus = long.Parse(arguments[4]);
            long hitPointsBonus = long.Parse(arguments[2]);
            long damageBonus = long.Parse(arguments[6]);

            CommonItem newItem = new CommonItem(
                itemName,
                strengthBonus,
                agilityBonus,
                intelligenceBonus,
                hitPointsBonus,
                damageBonus);

            this.heroes[heroName].AddItem(newItem);

            string result = string.Format(Constants.ItemCreateMessage, newItem.Name, heroName);
            return result;
        }

        public string AddRecipe(IList<string> arguments)
        {
            string name = arguments[0];
            string heroName = arguments[1];
            int strengthBonus = int.Parse(arguments[2]);
            int agilityBonus = int.Parse(arguments[3]);
            int intelligenceBonus = int.Parse(arguments[4]);
            int hitpointsBonus = int.Parse(arguments[5]);
            int damageBonus = int.Parse(arguments[6]);
            List<string> requiredItems = arguments.Skip(7).ToList();

            IRecipe recipe = new RecipeItem(name, strengthBonus, agilityBonus, intelligenceBonus, hitpointsBonus, damageBonus, requiredItems);
            this.heroes[heroName].AddRecipe(recipe);

            string result = string.Format(Constants.RecipeCreateMessage, recipe.Name, heroName);
            return result;
        }

        public string Inspect(IList<string> arguments)
        {
            string heroName = arguments[0];

            return this.heroes[heroName].ToString();
        }

        public string Quit()
        {
            int counter = 1;

            StringBuilder result = new StringBuilder();

            var sortedHeroes = this.heroes
                .Values
                .OrderByDescending(h => h.Strength + h.Intelligence + h.Agility)
                .ThenByDescending(h => h.HitPoints + h.Damage)
                .ToList();

            foreach (var hero in sortedHeroes)
            {
                string itemLine = hero.Items.Count == 0
                    ? string.Join(", ", hero.Items.Select(i => i.Name))
                    : "None";

                result
                    .AppendLine($"{counter}. {hero.GetType().Name}: {hero.Name}")
                    .AppendLine($"###HitPoints: {hero.HitPoints}")
                    .AppendLine($"###Damage: {hero.Damage}")
                    .AppendLine($"###Strength: {hero.Agility}")
                    .AppendLine($"###Agility: {hero.Agility}")
                    .AppendLine($"###Intelligence: {hero.Agility}")
                    .AppendLine($"###Items: {itemLine}");

                counter++;
            }

            return result.ToString().Trim();
        }
    }
}
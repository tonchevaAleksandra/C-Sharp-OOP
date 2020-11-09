using System;
using Raiding.Common;
using Raiding.Models;

namespace Raiding.Factories
{
   public class HeroFactory
    {
        public BaseHero CreateHero(string type, string name)
        {
            BaseHero hero = null;

            switch (type)
            {
                case "Druid":
                    hero = new Druid(name);
                    break;
                case "Paladin":
                    hero = new Paladin(name);
                    break;
                case "Rogue":
                    hero = new Rogue(name);
                    break;
                case "Warrior":
                    hero = new Warrior(name);
                    break;
            }

            if(hero==null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidHeroException);
            }

            return hero;
        }
    }
}

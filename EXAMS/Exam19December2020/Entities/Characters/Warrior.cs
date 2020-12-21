using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        private const double DefaultHealth = 100;
        private const double DefaultArmor = 50;
        private const double DefaultAbilityPoints = 40;


        public Warrior(string name)
            : base(name, DefaultHealth, DefaultArmor, DefaultAbilityPoints, new Satchel())
        {
        }

        public void Attack(Character character)
        {
            this.EnsureAlive();
            if (!character.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }

            if (this.Name == character.Name)
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
            }

            character.TakeDamage(this.AbilityPoints);

        }
    }
}

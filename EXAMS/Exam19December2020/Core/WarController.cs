using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private ICollection<Character> characters;
        private ICollection<Item> items;
        public WarController()
        {
            this.characters = new List<Character>();
            this.items = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];
            Character character = characterType switch
            {
                "Warrior" => new Warrior(name),
                "Priest" => new Priest(name),
                _ => throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType))
            };

            this.characters.Add(character);

            return string.Format(SuccessMessages.JoinParty, name);

        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];
            Item item = itemName switch
            {
                nameof(FirePotion) => new FirePotion(),
                nameof(HealthPotion) => new HealthPotion(),
                _ => throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName))

            };
            this.items.Add(item);

            return string.Format(SuccessMessages.AddItemToPool, itemName);
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            if(!this.characters.Any(c => c.Name == characterName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }
            if(!this.items.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

            Character character = this.characters.FirstOrDefault(c => c.Name == characterName);
            Item item = this.items.Last();
            character.Bag.AddItem(item);

            return string.Format(SuccessMessages.PickUpItem, characterName, item.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            if(!this.characters.Any(c=>c.Name==characterName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }
            Character character = this.characters.FirstOrDefault(c => c.Name == characterName);
            Item item = character.Bag.GetItem(itemName);
            character.UseItem(item);

            return string.Format(SuccessMessages.UsedItem, characterName, itemName);

        }

        public string GetStats()
        {
            var characters = this.characters.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health);
            StringBuilder sb = new StringBuilder();
            foreach (var character in characters)
            {
                sb.AppendLine(character.ToString());
            }

            return sb.ToString().Trim();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];
            if(!this.characters.Any(c=>c.Name==attackerName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }
            if (!this.characters.Any(c => c.Name == receiverName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }

            //if (this.characters.Where(c => c.GetType().Name == nameof(Warrior)).Any(c => c.Name == attackerName))
            //{
            //    throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
            //}
           
            Warrior attacker = (Warrior)this.characters.Where(c => c.GetType().Name == nameof(Warrior)).FirstOrDefault(c => c.Name == attackerName);
            if(!attacker.IsAlive)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
            }

            Character receiver = this.characters.FirstOrDefault(c => c.Name == receiverName);



            //Character attacker = this.characters.FirstOrDefault(c => c.Name == attackerName);
            //Character receiver = this.characters.FirstOrDefault(c => c.Name == receiverName);
            //if(!attacker.IsAlive)
            //{
            //    throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
            //}
            if (!receiver.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
            //receiver.TakeDamage(attacker.AbilityPoints);
            string msg = string.Empty;
            if (!receiver.IsAlive)
            {
                 msg = string.Format(SuccessMessages.AttackKillsCharacter, receiverName);
            }
            attacker.Attack(receiver);
            string output = string.Format(SuccessMessages.AttackCharacter, attackerName, receiverName, attacker.AbilityPoints, receiverName, receiver.Health, receiver.BaseHealth, receiver.Armor, receiver.BaseArmor);

            return receiver.IsAlive? output: $"{output}\n{ msg}" ;
          
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            if (!this.characters.Any(c => c.Name == healerName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }
            if (!this.characters.Any(c => c.Name == healingReceiverName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));
            }
            //if (this.characters.Where(c => c.GetType().Name == nameof(Priest)).Any(c => c.Name == healerName))
            //{
            //    throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            //}

            Priest healer = (Priest)this.characters.Where(c => c.GetType().Name == nameof(Priest)).FirstOrDefault(c => c.Name == healerName);
            Character healingReceiver = this.characters.FirstOrDefault(c => c.Name == healingReceiverName);

            healer.Heal(healingReceiver);

            //Character healer = this.characters.FirstOrDefault(c => c.Name == healerName);
            //Character healingReceiver = this.characters.FirstOrDefault(c => c.Name == healingReceiverName);
            //if (!healer.IsAlive)
            //{
            //    throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            //}


            return string.Format(SuccessMessages.HealCharacter, healer.Name, healingReceiver.Name, healer.AbilityPoints, healingReceiver.Name, healingReceiver.Health);

        }
    }
}

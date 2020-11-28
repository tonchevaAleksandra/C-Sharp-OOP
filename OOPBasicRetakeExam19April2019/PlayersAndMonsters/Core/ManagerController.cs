namespace PlayersAndMonsters.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Core.Factories;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Repositories.Contracts;

    public class ManagerController : IManagerController
    {
        private IPlayerRepository players;
        private IPlayerFactory playerFactory;
        private ICardRepository cards;
        private ICardFactory cardFactory;
        private IBattleField battleField;
        public ManagerController()
        {
            this.players = new PlayerRepository();
            this.playerFactory = new PlayerFactory();
            this.cards = new CardRepository();
            this.cardFactory = new CardFactory();
            this.battleField = new BattleField();
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player = this.playerFactory.CreatePlayer(type, username);
            this.players.Add(player);

            string outputMsg = string.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);

            return outputMsg;
        }

        public string AddCard(string type, string name)
        {
            ICard card = this.cardFactory.CreateCard(type, name);
            this.cards.Add(card);

            string outputMsg = string.Format(ConstantMessages.SuccessfullyAddedCard, type, name);

            return outputMsg;
        }

        public string AddPlayerCard(string username, string cardName)
        {
            IPlayer player = this.players.Players.FirstOrDefault(p => p.Username == username);
            ICard card = this.cards.Cards.FirstOrDefault(c => c.Name == cardName);

            player.CardRepository.Add(card);

            string outputMsg = string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);

            return outputMsg;
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attacker = this.players.Players.FirstOrDefault(p => p.Username == attackUser);
            IPlayer enemy = this.players.Players.FirstOrDefault(p => p.Username == enemyUser);

            this.battleField.Fight(attacker, enemy);

            string outputMsg = string.Format(ConstantMessages.FightInfo, attacker.Health, enemy.Health);

            return outputMsg;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var player in this.players.Players)
            {
                sb.Append(string.Format(ConstantMessages.PlayerReportInfo,player.Username, player.Health, player.CardRepository.Cards.Count));

                foreach (var card in player.CardRepository.Cards)
                {
                    sb.Append(string.Format(ConstantMessages.CardReportInfo, card.Name, card.DamagePoints));
                }
                sb.Append(ConstantMessages.DefaultReportSeparator);
            }

            return sb.ToString().Trim();
        }
    }
}

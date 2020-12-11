using CounterStrike.Core.Contracts;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Enums;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private readonly GunRepository guns;
        private readonly PlayerRepository players;
        private readonly IMap map;
        public Controller()
        {
            this.guns = new GunRepository();
            this.players = new PlayerRepository();
            this.map = new Map();

        }
        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun gun = CreateGun(type, name, bulletsCount);
            this.guns.Add(gun);

            return string.Format(OutputMessages.SuccessfullyAddedGun, name);
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            IGun gun = this.guns.Models.FirstOrDefault(g => g.Name == gunName);
            if (gun == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }
            IPlayer player = CreatePlayer(type, username, health, armor, gun);

            this.players.Add(player);

            return string.Format(OutputMessages.SuccessfullyAddedPlayer, username);
        }

        public string Report()
        {
            var playersReports =this.players.Models.OrderBy(p => p.GetType().Name).ThenByDescending(p => p.Health).ThenBy(p => p.Username);

            StringBuilder sb = new StringBuilder();

            foreach (var player in playersReports)
            {
                
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().Trim();
        }

        public string StartGame()
        {
            return this.map.Start(this.players.Models.Where(p => p.IsAlive).ToList());
        }
        private static IGun CreateGun(string type, string name, int bulletsCount)
        {
            IGun gun;
            Enum.TryParse(type, out GunType gunType);
            gun = gunType switch
            {
                GunType.Pistol => new Pistol(name, bulletsCount),
                GunType.Rifle => new Rifle(name, bulletsCount),
                _ => throw new ArgumentException(ExceptionMessages.InvalidGunType)
            };
            return gun;
        }
        private static IPlayer CreatePlayer(string type, string username, int health, int armor, IGun gun)
        {
            IPlayer player;
            Enum.TryParse(type, out PlayerType playerType);
            player = playerType switch
            {
                PlayerType.CounterTerrorist => new CounterTerrorist(username, health, armor, gun),
                PlayerType.Terrorist => new Terrorist(username, health, armor, gun),
                _ => throw new ArgumentException(ExceptionMessages.InvalidPlayerType)
            };
            return player;
        }


    }
}

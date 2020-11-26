using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Core.Contracts
{
    public class Controller : IController
    {
        private readonly GunRepository gunRepository;
        private readonly PlayerRepository playerRepository;
        private readonly IMap map;
        public Controller()
        {
            this.gunRepository = new GunRepository();
            this.playerRepository = new PlayerRepository();
            this.map = new Map();
        }

        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun gun = CreateGun(type, name, bulletsCount);
            
            this.gunRepository.Add(gun);

            string msg = string.Format(OutputMessages.SuccessfullyAddedGun, gun.Name);

            return msg;
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            IGun gun = this.gunRepository.FindByName(gunName);
            if(gun==null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }
            IPlayer player = CreatePlayer(type, username, health, armor, gun);
            this.playerRepository.Add(player);
            string msg = string.Format(OutputMessages.SuccessfullyAddedPlayer, player.Username);

            return msg;
        }

        public string Report()
        {
            var players = this.playerRepository.Models.OrderBy(p => p.GetType().Name).ThenByDescending(p => p.Health).ThenBy(p => p.Username);

            StringBuilder sb = new StringBuilder();

            foreach (var p in players)
            {
                sb.AppendLine(p.ToString());
            }

            return sb.ToString().Trim();
        }

        public string StartGame()
        {
           string result= this.map.Start(this.playerRepository.Models.ToList());

            return result;
        }
        private IGun CreateGun(string type, string name, int bulletsCount)
        {
            IGun gun = null;
            if (type == nameof(Pistol))
                gun = new Pistol(name, bulletsCount);
            else if (type == nameof(Rifle))
                gun = new Rifle(name, bulletsCount);
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }
            return gun;
        }

        private IPlayer CreatePlayer(string type, string username, int health, int armor, IGun gun)
        {
            IPlayer player = null;
            if (type == nameof(Terrorist))
                player = new Terrorist(username, health, armor, gun);
            else if (type == nameof(CounterTerrorist))
                player = new CounterTerrorist(username, health, armor, gun);
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }

            return player;
        }

    }
}

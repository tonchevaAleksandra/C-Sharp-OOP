using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        
        public string Start(ICollection<IPlayer> players)
        {
            var terrorists = players.Where(p => p.GetType().Name == nameof(Terrorist) ).ToList();
            var counterTerrorists = players.Where(p => p.GetType().Name == nameof(CounterTerrorist)).ToList();

            while (terrorists.Any(t=>t.IsAlive) && counterTerrorists.Any(c=>c.IsAlive))
            {
                foreach (var terrorist in terrorists.Where(p => p.IsAlive))
                {
                    foreach (var counterTerrorist in counterTerrorists.Where(p => p.IsAlive))
                    {
                        counterTerrorist.TakeDamage(terrorist.Gun.Fire());
                    }
                }

                foreach (var counterTerrorist in counterTerrorists.Where(p => p.IsAlive))
                {
                    foreach (var terrorist in terrorists.Where(p => p.IsAlive))
                    {
                        terrorist.TakeDamage(counterTerrorist.Gun.Fire());
                    }
                }
            }

            if (terrorists.Any(t => t.IsAlive))
                return "Terrorist wins!";
            else
                return "Counter Terrorist wins!";

        }
    }
}

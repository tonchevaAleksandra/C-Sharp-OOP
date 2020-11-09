using System;
using System.Collections.Generic;
using System.Linq;
using Raiding.Factories;
using Raiding.IO.Contracts;
using Raiding.Models;

namespace Raiding.Core
{
   public  class Engine
    {
        private IReadable reader;
        private IWritable writer;
        private readonly List<BaseHero> heroes;
        private HeroFactory heroFactory;
        public Engine(IReadable reader, IWritable writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.heroes = new List<BaseHero>();
            this.heroFactory = new HeroFactory();
        }
        public void Run()
        {
            FormTheRaidGroup();

            int bossPower = int.Parse(this.reader.ReadLine());

            int heroesPower=0;
            if (this.heroes.Count!=0)
            {
                foreach (var item in this.heroes)
                {
                    this.writer.WriteLine(item.CastAbility());
                }
                heroesPower = this.heroes.Sum(h => h.Power);
            }
               

            this.writer.WriteLine((heroesPower>= bossPower) ?
                "Victory!" : "Defeat...");


        }

        private void FormTheRaidGroup()
        {
            int count = int.Parse(this.reader.ReadLine());


            while (count>this.heroes.Count)
            {
                BaseHero hero = null;
                try
                {
                    string name = this.reader.ReadLine();
                    string type = this.reader.ReadLine();
                    hero = this.heroFactory.CreateHero(type, name);

                }
                catch (ArgumentException msg)
                {
                    this.writer.WriteLine(msg.Message);
                    continue;
                }

                if (hero != null) this.heroes.Add(hero); 
            }

           
        }
    }
}

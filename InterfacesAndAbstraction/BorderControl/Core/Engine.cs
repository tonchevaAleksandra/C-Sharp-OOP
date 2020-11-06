using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BorderControl.Contracts;
using BorderControl.Models;

namespace BorderControl.Core
{
   public class Engine
    {
        private readonly List<IInhabitable> inhabitants;
        public Engine()
        {
            this.inhabitants = new List<IInhabitable>();
        }

        public void Run()
        {
            string input;
            while ((input=Console.ReadLine())!="End")
            {
                string[] inhabitantsArgs = input
                    .Split()
                    .ToArray();
                if(inhabitantsArgs.Length==2)
                {
                    EnterRobot(inhabitantsArgs);
                }
                else
                {
                    EnterCitizen(inhabitantsArgs);
                }
            }

            string invalidID = Console.ReadLine();
            foreach (var inhabitant in this.inhabitants)
            {
                if(inhabitant.ID.EndsWith(invalidID))
                    Console.WriteLine(inhabitant.ID);
            }
        }

        private void EnterCitizen(string[] inhabitantsArgs)
        {
            string name = inhabitantsArgs[0];
            int age = int.Parse(inhabitantsArgs[1]);
            string id = inhabitantsArgs[2];
            Citizen citizen = new Citizen(name, age, id);
            inhabitants.Add(citizen);
        }

        private void EnterRobot(string[] inhabitantsArgs)
        {
            string model = inhabitantsArgs[0];
            string robotId = inhabitantsArgs[1];
            Robot robot = new Robot(model, robotId);
            inhabitants.Add(robot);
        }
    }
}

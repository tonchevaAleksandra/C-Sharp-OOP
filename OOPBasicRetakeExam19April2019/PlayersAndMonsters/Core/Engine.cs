using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private IManagerController controller;

        public Engine(IWriter writer, IReader reader)
        {
            this.writer = writer;
            this.reader = reader;
            this.controller = new ManagerController();
        }
        public void Run()
        {
            while (true)
            {
                try
                {
                    string[] arguments = this.reader.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                    string command = arguments[0];
                 
                    if (command == "AddPlayer")
                    {
                        this.writer.WriteLine(this.controller.AddPlayer(arguments[1], arguments[2]));
                    }
                   
                    else if (command=="AddCard")
                    {
                        this.writer.WriteLine(this.controller.AddCard(arguments[1], arguments[2]));
                    }
                    //•	AddPlayerCard {username} {card name}
                    else if (command== "AddPlayerCard")
                    {
                        this.writer.WriteLine(this.controller.AddPlayerCard(arguments[1], arguments[2]));
                    }
                    //•	Fight {attack user} {enemy user}
                    else if (command== "Fight")
                    {
                        this.writer.WriteLine(this.controller.Fight(arguments[1], arguments[2]));
                    }
                    else if(command=="Report")
                    {
                        this.writer.WriteLine(this.controller.Report());
                      
                    }
                    else if(command=="Exit")
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }

            }
        }
    }
}

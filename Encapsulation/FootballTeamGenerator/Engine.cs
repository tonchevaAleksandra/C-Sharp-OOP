using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FootballTeamGenerator.Models;

namespace FootballTeamGenerator
{
    public class Engine
    {
        private readonly List<Team> teams = new List<Team>();
        public Engine()
        {
          
        }

        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] cmdArgs = input
                               .Split(";", StringSplitOptions.RemoveEmptyEntries)
                               .ToArray();
                    string command = cmdArgs[0];
                    string[] arguments = cmdArgs.Skip(1).ToArray();
                    string teamName = arguments[0];
                    switch (command)
                    {
                        case "Team":

                            Team team = new Team(teamName);
                            this.teams.Add(team);

                            break;
                        case "Add":
                            AddPlayer(arguments, teamName);
                            break;
                        case "Remove":
                            RemovePlayer(arguments, teamName);

                            break;
                        case "Rating":
                            PrintTeamRating(teamName);
                            break;

                        default:
                            break;
                    }
                }
                catch (ArgumentException argEx)
                {
                    Console.WriteLine(argEx.Message);
                }
            }
        }

        private void AddPlayer(string[] arguments, string teamName)
        {
            if (CheckIfTeamExist(teamName))
            {
                string playerName = arguments[1];

                int endurance = int.Parse(arguments[2]);
                int sprint = int.Parse(arguments[3]);
                int dribble = int.Parse(arguments[4]);
                int passing = int.Parse(arguments[5]);
                int shooting = int.Parse(arguments[6]);

                Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                FindTeam(teamName).AddPlayer(player);
            }
            else
            {
                Console.WriteLine($"Team {teamName} does not exist.");
            }
        }

        private void RemovePlayer(string[] arguments, string teamName)
        {
            string playerN = arguments[1];
            if (CheckIfTeamExist(teamName))
            {
                FindTeam(teamName).RemovePlayer(playerN);
            }
        }

        private void PrintTeamRating(string teamName)
        {
            if (CheckIfTeamExist(teamName))
            {
                Console.WriteLine(FindTeam(teamName).ToString());
            }
            else
            {
                Console.WriteLine($"Team {teamName} does not exist.");
            }
        }

        private Team FindTeam(string teamName)
        {
            return this.teams.FirstOrDefault(t => t.Name == teamName);
        }

        private bool CheckIfTeamExist(string name)
        {
            if (this.teams.Count > 0 && this.teams.Any(t => t.Name == name))
            {
                return true;
            }
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Engine
{
    private RaceTower raceTower;

    public Engine(RaceTower raceTower)
    {
        this.raceTower = raceTower;
    }

    public void Run()
    {
        StringBuilder sb = new StringBuilder();

        while (!raceTower.IsRaceOver())
        {
            string output = string.Empty;
            string[] command = Console.ReadLine().Split();
            string type = command[0];
            List<string> commandArgs = command.Skip(1).ToList();

            switch (type)
            {
                case "RegisterDriver":
                    this.raceTower.RegisterDriver(commandArgs);
                    break;
                case "Leaderboard":
                    output = this.raceTower.GetLeaderboard();
                    break;
                case "CompleteLaps":
                    output = this.raceTower.CompleteLaps(commandArgs);
                    break;
                case "Box":
                    this.raceTower.DriverBoxes(commandArgs);
                    break;
                case "ChangeWeather":
                    this.raceTower.ChangeWeather(commandArgs);
                    break;
                default:
                    Console.WriteLine("Invalid command");
                    break;
            }

            if (!string.IsNullOrEmpty(output))
            {
                sb.AppendLine(output);
            }
        }

        sb.AppendLine(raceTower.GetWinner());

        Console.WriteLine(sb.ToString().TrimEnd());
    }
}

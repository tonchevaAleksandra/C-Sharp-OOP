using System.Linq;
using System.Collections.Generic;
using MilitaryElite.Models;
using MilitaryElite.Contracts;
using MilitaryElite.Core.Contracts;
using MilitaryElite.IO.Contracts;
using MilitaryElite.Exceptions;

namespace MilitaryElite.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        private ICollection<ISoldier> soldiers;
        public Engine()
        {
            this.soldiers = new List<ISoldier>();
        }
        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string command;
            while ((command = this.reader.ReadLine()) != "End")
            {
                string[] cmdArg = command
                    .Split()
                    .ToArray();

                string soldierType = cmdArg[0];
                int id = int.Parse(cmdArg[1]);
                string firstName = cmdArg[2];
                string lastName = cmdArg[3];
                decimal salary;
                ISoldier soldier = null;

                switch (soldierType)
                {
                    case "Private":
                        soldier = AddPrivate(cmdArg, id, firstName, lastName);
                        break;
                    case "LieutenantGeneral":
                        soldier = AddGeneral(cmdArg, id, firstName, lastName, out soldier, out salary);
                        break;
                    case "Engineer":
                        salary = decimal.Parse(cmdArg[4]);
                        string corps = cmdArg[5];
                        try
                        {
                            soldier = CreateEngineer(cmdArg, id, firstName, lastName, salary, corps);
                        }
                        catch (InvalidCorpsException)
                        {
                            continue;
                        }
                        break;
                    case "Commando":
                        salary = decimal.Parse(cmdArg[4]);
                        corps = cmdArg[5];

                        try
                        {
                            ICommando commando = CreateCommando(cmdArg, id, firstName, lastName, salary, corps);

                            soldier = commando;
                        }
                        catch (InvalidCorpsException)
                        {
                            continue;
                        }
                        break;
                    case "Spy":
                        soldier = AddSpy(cmdArg, id, firstName, lastName);
                        break;
                    default:
                        break;
                }

                if (soldier != null)
                {
                    this.soldiers.Add(soldier);
                }

            }

            foreach (var soldier in this.soldiers)
            {
                this.writer.WriteLine(soldier.ToString());
            }
        }

        private  ISoldier AddSpy(string[] cmdArg, int id, string firstName, string lastName)
        {
            ISoldier soldier;
            int codeNumber = int.Parse(cmdArg[4]);
            soldier = new Spy(id, firstName, lastName, codeNumber);
            return soldier;
        }

        private  ICommando CreateCommando(string[] cmdArg, int id, string firstName, string lastName, decimal salary, string corps)
        {
            ICommando commando = new Commando(id, firstName, lastName, salary, corps);
            string[] missionArgs = cmdArg.Skip(6).ToArray();
            for (int i = 0; i < missionArgs.Length; i += 2)
            {
                try
                {
                    string missionCodeName = missionArgs[i];
                    string missionState = missionArgs[i + 1];
                    IMission mission = new Mission(missionCodeName, missionState);

                    commando.AddMission(mission);
                }
                catch (InvalidMissionStateException)
                {
                    continue;
                }

            }

            return commando;
        }

        private  ISoldier CreateEngineer(string[] cmdArg, int id, string firstName, string lastName, decimal salary, string corps)
        {
            ISoldier soldier;
            IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);
            string[] repairArgs = cmdArg.Skip(6).ToArray();
            for (int i = 0; i < repairArgs.Length; i += 2)
            {
                string partName = repairArgs[i];
                int hoursWorked = int.Parse(repairArgs[i + 1]);

                IRepair repair = new Repair(partName, hoursWorked);

                engineer.AddRepair(repair);
            }

            soldier = engineer;
            return soldier;
        }

        private ISoldier AddGeneral(string[] cmdArg, int id, string firstName, string lastName, out ISoldier soldier, out decimal salary)
        {
            salary = decimal.Parse(cmdArg[4]);
            ILieutenantGeneral general = new LieutenantGeneral(id, firstName, lastName, salary);
            foreach (var pid in cmdArg.Skip(5))
            {
                ISoldier privateToAdd = this.soldiers.First(s => s.ID == int.Parse(pid));

                general.AddPrivate(privateToAdd);
            }
            soldier = general;
            return soldier;
        }

        private ISoldier AddPrivate(string[] cmdArg, int id, string firstName, string lastName)
        {
            ISoldier soldier;
            decimal salary = decimal.Parse(cmdArg[4]);
            soldier = new Private(id, firstName, lastName, salary);
            return soldier;
        }
    }
}

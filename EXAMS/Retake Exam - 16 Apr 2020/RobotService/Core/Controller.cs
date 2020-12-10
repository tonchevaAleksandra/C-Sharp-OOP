using RobotService.Core.Contracts;
using RobotService.Enums;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private readonly IGarage garage;
        private readonly Dictionary<ProcedureType, IProcedure> procedures;
        public Controller()
        {
            this.garage = new Garage();
            this.procedures = new Dictionary<ProcedureType, IProcedure>();
            this.CreateProcedures();
        }
        public string Charge(string robotName, int procedureTime)
        {
            IRobot robot = this.ExtractRobot(robotName);
            IProcedure procedure = this.procedures[ProcedureType.Charge];
            procedure.DoService(robot, procedureTime);

            return string.Format(OutputMessages.ChargeProcedure, robotName);
        }

        public string Chip(string robotName, int procedureTime)
        {
            IRobot robot = this.ExtractRobot(robotName);
            IProcedure procedure = this.procedures[ProcedureType.Chip];
            procedure.DoService(robot, procedureTime);

            return string.Format(OutputMessages.ChipProcedure, robotName);
        }

        public string History(string procedureType)
        {
            Enum.TryParse(procedureType, out ProcedureType procedureTypeEnum);

            IProcedure procedure = this.procedures[procedureTypeEnum];

            return procedure.History();
        }


        private void CreateProcedures()
        {
            this.procedures.Add(ProcedureType.Chip, new Chip());
            this.procedures.Add(ProcedureType.Charge, new Charge());
            this.procedures.Add(ProcedureType.Rest, new Rest());
            this.procedures.Add(ProcedureType.Polish, new Polish());
            this.procedures.Add(ProcedureType.Work, new Work());
            this.procedures.Add(ProcedureType.TechCheck, new TechCheck());
        }
        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot = CreateRobot(robotType, name, energy, happiness, procedureTime);

            this.garage.Manufacture(robot);

            return string.Format(OutputMessages.RobotManufactured, robot.Name);

        }


        public string Polish(string robotName, int procedureTime)
        {
            IRobot robot = this.ExtractRobot(robotName);
            IProcedure procedure = this.procedures[ProcedureType.Polish];
            procedure.DoService(robot, procedureTime);

            return string.Format(OutputMessages.PolishProcedure, robotName);
        }

        public string Rest(string robotName, int procedureTime)
        {
            IRobot robot = this.ExtractRobot(robotName);
            IProcedure procedure = this.procedures[ProcedureType.Rest];
            procedure.DoService(robot, procedureTime);

            return string.Format(OutputMessages.RestProcedure, robotName);
        }

        public string Sell(string robotName, string ownerName)
        {
            IRobot robot = this.ExtractRobot(robotName);
            this.garage.Sell(robotName, ownerName);
            if (robot.IsChipped)
            {
                return string.Format(OutputMessages.SellChippedRobot, ownerName);
            }

            return string.Format(OutputMessages.SellNotChippedRobot, ownerName);
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            IRobot robot = this.ExtractRobot(robotName);
            IProcedure procedure = this.procedures[ProcedureType.TechCheck];
            procedure.DoService(robot, procedureTime);

            return string.Format(OutputMessages.TechCheckProcedure, robotName);
        }

        public string Work(string robotName, int procedureTime)
        {
            IRobot robot = this.ExtractRobot(robotName);
            IProcedure procedure = this.procedures[ProcedureType.Work];
            procedure.DoService(robot, procedureTime);

            return string.Format(OutputMessages.WorkProcedure, robotName, procedureTime);
        }

        private IRobot ExtractRobot(string name)
        {
            if (!this.garage.Robots.ContainsKey(name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, name));
            }

            return this.garage.Robots.FirstOrDefault(r => r.Key == name).Value;
        }
        private static IRobot CreateRobot(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot;
            Enum.TryParse(robotType, out RobotType type);
            robot = type switch
            {
                RobotType.HouseholdRobot => new HouseholdRobot(name, energy, happiness, procedureTime),
                RobotType.PetRobot => new PetRobot(name, energy, happiness, procedureTime),
                RobotType.WalkerRobot => new WalkerRobot(name, energy, happiness, procedureTime),
                _ => throw new ArgumentException(string.Format(ExceptionMessages.InvalidRobotType, robotType))
            };
            return robot;
        }
    }
}

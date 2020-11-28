using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Enums;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
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
            IRobot robot = GetRobotByName(robotName);
            IProcedure procedure = this.procedures[ProcedureType.Charge];
            procedure.DoService(robot, procedureTime);

            string outputMsg = string.Format(OutputMessages.ChargeProcedure, robotName);
            return outputMsg;
        }

        public string Chip(string robotName, int procedureTime)
        {
            IRobot robot = GetRobotByName(robotName);
            IProcedure procedure = this.procedures[ProcedureType.Chip];
            procedure.DoService(robot, procedureTime);

            string outputMsg = string.Format(OutputMessages.ChipProcedure, robotName);
            return outputMsg;

        }

        public string History(string procedureType)
        {
            Enum.TryParse(procedureType, out ProcedureType procedureTypeEnum);

            IProcedure procedure = this.procedures[procedureTypeEnum];

            return procedure.History();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            if (!Enum.TryParse(robotType, out RobotType robotTypeName))
            {
                string msg = string.Format(ExceptionMessages.InvalidRobotType, robotType);
                throw new ArgumentException(msg);
            }

            IRobot robot = CreateRobot(name, energy, happiness, procedureTime, robotTypeName);

            this.garage.Manufacture(robot);

            string outputMsg = string.Format(OutputMessages.RobotManufactured, robot.Name);

            return outputMsg;
        }


        public string Polish(string robotName, int procedureTime)
        {

            IRobot robot = GetRobotByName(robotName);
            IProcedure procedure = this.procedures[ProcedureType.Polish];
            procedure.DoService(robot, procedureTime);

            string outputMsg = string.Format(OutputMessages.PolishProcedure, robotName);
            return outputMsg;
        }

        public string Rest(string robotName, int procedureTime)
        {
            IRobot robot = GetRobotByName(robotName);
            IProcedure procedure = this.procedures[ProcedureType.Rest];
            procedure.DoService(robot, procedureTime);

            string outputMsg = string.Format(OutputMessages.RestProcedure, robotName);
            return outputMsg;
        }

        public string Sell(string robotName, string ownerName)
        {
            IRobot robot = GetRobotByName(robotName);
            this.garage.Sell(robotName, ownerName);

            string outputMsg;
            if (robot.IsChipped)
            {
                outputMsg = string.Format(OutputMessages.SellChippedRobot, ownerName);
               
            }
            else
            {
                outputMsg = string.Format(OutputMessages.SellNotChippedRobot, ownerName);
               
            }

            return outputMsg;
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            IRobot robot = this.GetRobotByName(robotName);
            IProcedure procedure = this.procedures[ProcedureType.TechCheck];
            procedure.DoService(robot, procedureTime);

            string outputMsg = string.Format(OutputMessages.TechCheckProcedure, robotName);
            return outputMsg;
        }

        public string Work(string robotName, int procedureTime)
        {
            IRobot robot = this.GetRobotByName(robotName);
            IProcedure procedure = this.procedures[ProcedureType.Work];
            procedure.DoService(robot, procedureTime);

            string outputMsg = string.Format(OutputMessages.WorkProcedure, robotName, procedureTime);
            return outputMsg;
        }
        private static IRobot CreateRobot(string name, int energy, int happiness, int procedureTime, RobotType robotTypeName)
        {
            IRobot robot = null;

            switch (robotTypeName)
            {
                case RobotType.PetRobot:
                    robot = new PetRobot(name, energy, happiness, procedureTime);
                    break;
                case RobotType.HouseholdRobot:
                    robot = new HouseholdRobot(name, energy, happiness, procedureTime);
                    break;
                case RobotType.WalkerRobot:
                    robot = new WalkerRobot(name, energy, happiness, procedureTime);
                    break;

            }

            return robot;
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

        private IRobot GetRobotByName(string robotName)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                string msg = string.Format(ExceptionMessages.InexistingRobot, robotName);
                throw new ArgumentException(msg);
            }
            return this.garage.Robots[robotName];
        }
    }
}

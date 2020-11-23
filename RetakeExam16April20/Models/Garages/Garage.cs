using System;
using System.Collections.Generic;

using RobotService.Models.Robots.Contracts;
using RobotService.Models.Garages.Contracts;
using RobotService.Utilities.Messages;
using System.Linq;

namespace RobotService.Models.Garages
{
    public class Garage : IGarage
    {
        private const int Capacity = 10;
        private readonly Dictionary<string, IRobot> robots;

        public Garage()
        {
            this.robots = new Dictionary<string, IRobot>();
        }
        public IReadOnlyDictionary<string, IRobot> Robots => this.robots;

        public void Manufacture(IRobot robot)
        {
            if(this.robots.Count==Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            if(this.robots.ContainsKey(robot.Name))
            {
                string msg = string.Format(ExceptionMessages.ExistingRobot, robot.Name);
                throw new ArgumentException(msg);

            }

            this.robots.Add(robot.Name,robot);
        }

        public void Sell(string robotName, string ownerName)
        {
            if(!this.robots.ContainsKey(robotName))
            {
                string msg = string.Format(ExceptionMessages.InexistingRobot, robotName);
                throw new ArgumentException(msg);
            }

            IRobot robot = this.robots[robotName];

            robot.Owner = ownerName;
            robot.IsBought = true;
            this.robots.Remove(robotName);
        }
    }
}

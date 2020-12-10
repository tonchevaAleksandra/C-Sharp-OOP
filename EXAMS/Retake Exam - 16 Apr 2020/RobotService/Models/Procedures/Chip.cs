using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public class Chip : Procedure
    {
        public Chip()
        {
        }

        public override void DoService(IRobot robot, int procedureTime)
        {

            base.DoService(robot, procedureTime);
            if(robot.IsChipped)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AlreadyChipped, robot.Name));
            }

            robot.IsChipped = true;
            robot.Happiness -= 5;
            robot.ProcedureTime -= procedureTime;
            this.Robots.Add(robot);
        }
    }
}

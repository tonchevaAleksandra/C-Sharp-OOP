using System;

using RobotService.Utilities.Messages;
using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public class Chip : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            if(robot.IsChipped)
            {
                string msg = string.Format(ExceptionMessages.AlreadyChipped, robot.Name);
                throw new ArgumentException(msg);
            }
            robot.ProcedureTime -= procedureTime;
            robot.Happiness -= 5;
            robot.IsChipped = true;

            this.Robots.Add(robot);
           
        }
    }
}

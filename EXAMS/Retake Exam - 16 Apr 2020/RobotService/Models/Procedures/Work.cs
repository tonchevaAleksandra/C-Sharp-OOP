using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public class Work : Procedure
    {
        public Work()
        {
        }

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            robot.Energy -= 6;
            robot.Happiness += 12;
            robot.ProcedureTime -= procedureTime;
            this.Robots.Add(robot);
        }
    }
}

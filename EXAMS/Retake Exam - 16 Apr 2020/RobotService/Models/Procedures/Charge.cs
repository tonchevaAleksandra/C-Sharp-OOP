using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public class Charge : Procedure
    {
        public Charge()
        {
        }

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            robot.Happiness += 12;
            robot.Energy += 10;
            robot.ProcedureTime -= procedureTime;
            this.Robots.Add(robot);
        }
    }
}

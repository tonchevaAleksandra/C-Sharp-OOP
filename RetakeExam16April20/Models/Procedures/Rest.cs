﻿using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
   public class Rest:Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            robot.ProcedureTime -= procedureTime;
            robot.Happiness -= 3;
            robot.Energy += 10;

            this.Robots.Add(robot);
        }
    }
}

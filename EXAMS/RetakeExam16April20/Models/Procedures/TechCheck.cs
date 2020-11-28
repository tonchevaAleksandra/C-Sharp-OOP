using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
   public class TechCheck:Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            robot.ProcedureTime -= procedureTime;
            robot.Energy -= 8;
            robot.IsChecked = true;

            this.Robots.Add(robot);
        }
    }
}

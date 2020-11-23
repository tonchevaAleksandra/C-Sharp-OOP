using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public class Polish : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            robot.ProcedureTime -= procedureTime;
            robot.Happiness -= 7;

            this.Robots.Add(robot);
        }
    }
}

using System;
using System.Text;
using System.Collections.Generic;

using RobotService.Utilities.Messages;
using RobotService.Models.Robots.Contracts;
using RobotService.Models.Procedures.Contracts;

namespace RobotService.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected Procedure()
        {
            this.Robots = new List<IRobot>();
        }
        protected IList<IRobot> Robots { get; }
        public virtual void DoService(IRobot robot, int procedureTime)
        {
            
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }
        }

        public string History()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(this.GetType().Name);

            foreach (IRobot robot in this.Robots)
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}

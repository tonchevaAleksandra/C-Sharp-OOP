using System.Text;
using System.Collections.Generic;

using Logger.Models.Contracts;

namespace Logger.Models
{
    public class Logger : ILogger
    {
        private ICollection<IAppender> appenders;
        public Logger(ICollection<IAppender> appenders)
        {
            this.appenders = appenders;
        }
        public IReadOnlyCollection<IAppender> Appenders => (IReadOnlyCollection<IAppender>) this.appenders;

        public void Log(IError error)
        {
            foreach (IAppender appender in this.appenders)
            {
                if(appender.Level<=error.Level)
                {
                    appender.Append(error);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Logger info");
            foreach (IAppender appender in this.appenders)
            {
                sb.AppendLine(appender.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}

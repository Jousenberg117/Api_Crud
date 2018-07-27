using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Student.Common.Logic.Log4net
{
    public class Log4netAdapter : ILogger
    {

        private readonly ILog log;

        public Log4netAdapter()
        {
            this.log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        public void Debug(object message)
        {
            this.log.Debug(message);
        }

        public void Error(object message)
        {
            this.log.Error(message);
        }

    }
}

using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIP_LCMP.Utilities.LogManager
{
    public class LogManager : ILogManager
    {
        protected ILog _logger { get; set; }
        public LogManager()
        {
            _logger = log4net.LogManager.GetLogger(GetType());
        }
        public void LogError(string message)
        {
            _logger.Error(message);
        }

        public void LogError(string message, Exception exception)
        {
            _logger.Error(message, exception);
        }

        public void LogInfo(object info)
        {
            _logger.Info(info);
        }
    }
}

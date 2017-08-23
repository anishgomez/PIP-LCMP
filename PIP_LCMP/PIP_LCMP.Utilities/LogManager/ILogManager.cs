using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIP_LCMP.Utilities.LogManager
{
    public interface ILogManager
    {
        void LogInfo(object info);
        void LogError(string message);
        void LogError(string message, Exception exception);
    }
}

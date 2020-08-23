using NLog;

namespace Xian.Lib.Core.Utility
{
    public static class LoggerUtility
    {
        public static Logger GetLogger()
        {
            return LogManager.GetCurrentClassLogger();
        }
    }
}
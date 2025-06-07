using FinalProject.Contracts;
using NLog;

namespace FinalProject.LoggerService
{
    /// <summary>
    /// Logger manager class implementing ILoggerManager interface.
    /// </summary>
    public class LoggerManager : ILoggerManager
    {
        // Static logger instance from NLog
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes a new instance of the LoggerManager class.
        /// </summary>
        public LoggerManager()
        {
            // Constructor can be used for initialization if needed
        }

        /// <summary>
        /// Logs a debug message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void LogDebug(string message) => logger.Debug(message);

        /// <summary>
        /// Logs an error message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void LogError(string message) => logger.Error(message);

        /// <summary>
        /// Logs an informational message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void LogInfo(string message) => logger.Info(message);

        /// <summary>
        /// Logs a warning message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void LogWarn(string message) => logger.Warn(message);
    }
}
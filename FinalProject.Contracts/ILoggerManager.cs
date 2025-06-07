namespace FinalProject.Contracts
{
    public interface ILoggerManager
    {
        void LogInfo(string message);  // Method to log informational messages
        void LogWarn(string message);  // Method to log warning messages
        void LogDebug(string message); // Method to log debugging messages
        void LogError(string message); // Method to log error messages
    }
}

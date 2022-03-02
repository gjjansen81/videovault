namespace VideoVault.Domain
{
    public interface ILog
    {
        void LogDebug(string logMessage, string inputData = null);
        void LogError(int validationError, string logMessage, string inputData = null);
        void LogTrace(string logMessage, string inputData = null, string outputData = null);
        void LogTrace(string logMessage, string inputData = null);
    }
}
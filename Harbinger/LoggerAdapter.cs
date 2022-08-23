using Xunit.Abstractions;

namespace Harbinger
{
    internal sealed class LoggerAdapter
    {
        private static readonly LoggerAdapter instance = new();

        static LoggerAdapter()
        {
        }

        private LoggerAdapter()
        {
            _loggerName = string.Empty;
        }

        public static LoggerAdapter Instance => instance;

        private ILogger _iLogger;

        private ITestOutputHelper _testOutputHelper;

        private string _loggerName;

        public void SetLogger(ILogger logger)
        {
            if (!string.IsNullOrWhiteSpace(_loggerName))
            {
                throw new InvalidOperationException(nameof(_loggerName));
            }

            _loggerName = "Ilogger";
            _iLogger = logger;
        }

        public void SetLogger(ITestOutputHelper logger)
        {
            if (!string.IsNullOrWhiteSpace(_loggerName))
            {
                throw new InvalidOperationException(nameof(_loggerName));
            }

            _loggerName = "ITestOutputHelper";
            _testOutputHelper = logger;
        }

        public void WriteLine(string line)
        {
            if (_loggerName == "ILogger")
            {
                _iLogger.LogInformation(line);
            }
            else if (_loggerName == "ITestOutputHelper")
            {
                _testOutputHelper.WriteLine(line);
            }

            Console.WriteLine(line);
        }

        public void Error(Exception ex, string message = "")
        {
            if (_loggerName == "ILogger")
            {
                _iLogger.LogError(ex, message);
            }
            else if (_loggerName == "ITestOutputHelper")
            {
                _testOutputHelper.WriteLine($"An error occured for request {message}");
                _testOutputHelper.WriteLine(ex.Message);
                _testOutputHelper.WriteLine(ex.StackTrace);
            }

            Console.WriteLine($"An error occured for request {message}");
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
        }
    }
}

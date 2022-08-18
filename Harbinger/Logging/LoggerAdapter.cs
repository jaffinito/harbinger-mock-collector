using Xunit.Abstractions;

namespace Harbinger.Logging
{
    public sealed class LoggerAdapter
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
    }
}

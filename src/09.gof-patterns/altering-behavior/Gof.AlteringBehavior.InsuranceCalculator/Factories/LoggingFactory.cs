using System.Diagnostics;
using Gof.AlteringBehavior.InsuranceCalculator.Interfaces;

namespace Gof.AlteringBehavior.InsuranceCalculator.Factories
{
    public static class LoggingFactory
    {
        public static ILogger CreateLogger()
        {
            Action<string> loggingDelegate = Console.WriteLine + new Action<string>(message => Debug.WriteLine(message));

            return new DelegateLogger(loggingDelegate);
        }

        private class DelegateLogger : ILogger
        {
            private readonly Action<string> _loggingDelegate;

            public DelegateLogger(Action<string> loggingDelegate)
            {
                _loggingDelegate = loggingDelegate ?? throw new ArgumentNullException(nameof(loggingDelegate));
            }

            public void Log(string message)
            {
                _loggingDelegate(message);
            }
        }
    }
}

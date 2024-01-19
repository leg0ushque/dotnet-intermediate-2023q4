using Gof.AlteringBehavior.InsuranceCalculator.Interfaces;
using Gof.AlteringBehavior.InsuranceCalculator.Services.Decorators;

namespace Gof.AlteringBehavior.InsuranceCalculator.Builders
{
    public class DefaultBuilder : ICalculatorBuilder
    {
        private ICalculator _calculator;

        public DefaultBuilder(ICalculator calculator)
        {
            _calculator = calculator;
        }

        public ICalculatorBuilder AddCaching()
        {
            _calculator = new InsurancePaymentCachedCalculator(_calculator);

            return this;
        }

        public ICalculatorBuilder AddRounding()
        {
            _calculator = new InsurancePaymentRoundingCalculator(_calculator);

            return this;
        }

        public ICalculatorBuilder AddLogging(ILogger logger)
        {
            _calculator = new InsurancePaymentLoggingCalculator(_calculator, logger);

            return this;
        }

        public ICalculator CreateCalculator()
        {
            return _calculator;
        }
    }
}

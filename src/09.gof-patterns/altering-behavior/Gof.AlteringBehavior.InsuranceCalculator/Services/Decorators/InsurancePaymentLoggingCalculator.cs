using Gof.AlteringBehavior.InsuranceCalculator.Interfaces;

namespace Gof.AlteringBehavior.InsuranceCalculator.Services.Decorators
{
    public class InsurancePaymentLoggingCalculator : InsurancePaymentCalculationDecorator
    {
        private readonly ILogger _logger;

        public InsurancePaymentLoggingCalculator(ICalculator calculator, ILogger logger)
            : base(calculator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public override decimal CalculatePayment(string touristName)
        {
            _logger.Log("Calculating payment...");
            var calculatedValue = base.CalculatePayment(touristName);
            _logger.Log($"Calculated payment value: {calculatedValue}");

            return calculatedValue;
        }
    }
}

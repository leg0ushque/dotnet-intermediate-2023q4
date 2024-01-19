using Gof.AlteringBehavior.InsuranceCalculator.Interfaces;

namespace Gof.AlteringBehavior.InsuranceCalculator.Services.Decorators
{
    public abstract class InsurancePaymentCalculationDecorator : ICalculator
    {
        private readonly ICalculator _calculator;

        protected InsurancePaymentCalculationDecorator(ICalculator calculator)
        {
            _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
        }

        public virtual decimal CalculatePayment(string touristName)
        {
            return _calculator.CalculatePayment(touristName);
        }
    }
}

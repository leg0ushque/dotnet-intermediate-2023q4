using Gof.AlteringBehavior.InsuranceCalculator.Interfaces;

namespace Gof.AlteringBehavior.InsuranceCalculator.Services.Decorators
{
    internal class InsurancePaymentCachedCalculator : InsurancePaymentCalculationDecorator
    {
        private readonly Dictionary<string, decimal> _cachedValues = new Dictionary<string, decimal>();

        public InsurancePaymentCachedCalculator(ICalculator calculator)
            : base(calculator)
        {
        }

        public override decimal CalculatePayment(string touristName)
        {
            if (!_cachedValues.ContainsKey(touristName))
            {
                _cachedValues[touristName] = base.CalculatePayment(touristName);
            }

            return _cachedValues[touristName];
        }
    }
}

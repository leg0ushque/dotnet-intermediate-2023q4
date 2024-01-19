using Gof.AlteringBehavior.InsuranceCalculator.Interfaces;

namespace Gof.AlteringBehavior.InsuranceCalculator.Services.Decorators
{
    public class InsurancePaymentRoundingCalculator : InsurancePaymentCalculationDecorator
    {
        public InsurancePaymentRoundingCalculator(ICalculator calculator)
            : base(calculator)
        {
        }

        public override decimal CalculatePayment(string touristName)
        {
            var calculatedValue = base.CalculatePayment(touristName);

            return Math.Round(calculatedValue);
        }
    }
}

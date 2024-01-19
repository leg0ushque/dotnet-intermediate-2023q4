using Gof.AlteringBehavior.InsuranceCalculator.Builders;
using Gof.AlteringBehavior.InsuranceCalculator.Interfaces;
using Gof.AlteringBehavior.InsuranceCalculator.Services;

namespace Gof.AlteringBehavior.InsuranceCalculator.Factories
{
    public static class InsuranceCalculatorFactory
    {
        public static ICalculator CreateCalculator()
        {
            return new InsurancePaymentCalculator(
                new MoqCurrencyService(),
                new MoqTripRepository()
            );
        }

        public static ICalculatorBuilder CreateCalculatorBuilder()
        {
            return new DefaultBuilder(CreateCalculator());
        }
    }
}

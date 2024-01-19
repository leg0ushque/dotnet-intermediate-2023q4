using Gof.AlteringBehavior.InsuranceCalculator.Interfaces;

namespace Gof.AlteringBehavior.InsuranceCalculator.Services
{
    public class MoqCurrencyService : ICurrencyService
    {
        public decimal LoadCurrencyRate()
        {
            return 0.45m;
        }
    }
}

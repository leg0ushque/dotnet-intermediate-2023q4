using Gof.AlteringBehavior.InsuranceCalculator.Interfaces;

namespace Gof.AlteringBehavior.InsuranceCalculator.Services
{
    public class InsurancePaymentCalculator : ICalculator
    {
        private readonly ITripRepository _tripRepository;
        private readonly ICurrencyService _currencyService;

        public InsurancePaymentCalculator(
            ICurrencyService currencyService,
            ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
            _currencyService = currencyService;
        }

        public decimal CalculatePayment(string touristName)
        {
            if (string.IsNullOrEmpty(touristName))
            {
                throw new ArgumentException(nameof(touristName));
            }

            var tripDetails = _tripRepository.LoadTrip(touristName);
            var currencyRate = _currencyService.LoadCurrencyRate();

            return tripDetails.FlyCost * currencyRate
                + tripDetails.AccomodationCost * currencyRate
                + tripDetails.ExcursionCost * currencyRate;
        }
    }
}

using Gof.AlteringBehavior.InsuranceCalculator.Interfaces;
using Gof.AlteringBehavior.InsuranceCalculator.Models;

namespace Gof.AlteringBehavior.InsuranceCalculator.Services
{
    public class MoqTripRepository : ITripRepository
    {
        private readonly TripDetails[] _inMemoryTripDetails = new TripDetails[]
        {
            new TripDetails
            {
                TouristName = "touristName#1",
                FlyCost = 1,
                AccomodationCost = 1,
                ExcursionCost = 1,
            },
            new TripDetails
            {
                TouristName = "touristName#2",
                FlyCost = 2,
                AccomodationCost = 2,
                ExcursionCost = 2,
            },
            new TripDetails
            {
                TouristName = "touristName#3",
                FlyCost = 3,
                AccomodationCost = 3,
                ExcursionCost = 3,
            },
            new TripDetails
            {
                TouristName = "touristName#4",
                FlyCost = 4,
                AccomodationCost = 4,
                ExcursionCost = 4,
            },
            new TripDetails
            {
                TouristName = "touristName#5",
                FlyCost = 5,
                AccomodationCost = 5,
                ExcursionCost = 5,
            },
        };

        public TripDetails LoadTrip(string touristName)
        {
            return _inMemoryTripDetails.SingleOrDefault(t => t.TouristName == touristName);
        }
    }
}

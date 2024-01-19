using Gof.AlteringBehavior.InsuranceCalculator.Models;

namespace Gof.AlteringBehavior.InsuranceCalculator.Interfaces
{
    public interface ITripRepository
    {
        TripDetails LoadTrip(string touristName);
    }
}

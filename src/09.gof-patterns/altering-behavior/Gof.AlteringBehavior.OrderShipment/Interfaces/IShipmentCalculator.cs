using Gof.AlteringBehavior.OrderShipment.Models;

namespace Gof.AlteringBehavior.OrderShipment.Interfaces
{
    public interface IShipmentCalculator
    {
        double CalculatePrice(Order order);
    }
}

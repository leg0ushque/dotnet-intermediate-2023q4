using Gof.AlteringBehavior.OrderShipment.Models;
using Gof.AlteringBehavior.OrderShipment.Interfaces;

namespace Gof.AlteringBehavior.OrderShipment.Services
{

    public class ShipmentCalculatorUPS : IShipmentCalculator
    {
        private const double Coefficient = 1.1;
        private const double PriceValue = 4.25d;
        private const double ComparisonValue = 400;

        public double CalculatePrice(Order order)
        {
            return order.Weight > ComparisonValue
                ? PriceValue * Coefficient
                : PriceValue;
        }
    }
}

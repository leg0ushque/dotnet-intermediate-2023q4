using Gof.AlteringBehavior.OrderShipment.Models;
using Gof.AlteringBehavior.OrderShipment.Interfaces;

namespace Gof.AlteringBehavior.OrderShipment.Services
{
    public class ShipmentCalculatorFedEx : IShipmentCalculator
    {
        private const double Coefficient = 1.1;
        private const double PriceValue = 5.00d;
        private const double ComparisonValue = 300;

        public double CalculatePrice(Order order)
        {
            return order.Weight > ComparisonValue
                ? PriceValue * Coefficient
                : PriceValue;
        }
    }
}

using Gof.AlteringBehavior.OrderShipment.Models;
using Gof.AlteringBehavior.OrderShipment.Models.Enums;
using Gof.AlteringBehavior.OrderShipment.Interfaces;

namespace Gof.AlteringBehavior.OrderShipment.Services
{
    public class ShipmentCalculatorUSPS : IShipmentCalculator
    {
        private const double Coefficient = 0.9;
        private const double PriceValue = 3.00d;

        public double CalculatePrice(Order order)
        {
            return order.Product == ProductType.Book
                ? PriceValue * Coefficient
                : PriceValue;
        }
    }
}

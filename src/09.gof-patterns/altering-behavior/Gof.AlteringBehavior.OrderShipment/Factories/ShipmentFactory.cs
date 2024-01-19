using Gof.AlteringBehavior.OrderShipment.Interfaces;
using Gof.AlteringBehavior.OrderShipment.Models.Enums;
using Gof.AlteringBehavior.OrderShipment.Services;

namespace Gof.AlteringBehavior.OrderShipment.Factories
{
    public static class ShipmentFactory
    {
        private static readonly Dictionary<ShipmentOptions, Func<IShipmentCalculator>> _shipmentOptionCalculatorPairs = new()
        {
            { ShipmentOptions.USPS,  () => new ShipmentCalculatorUSPS() },
            { ShipmentOptions.UPS,   () => new ShipmentCalculatorUPS() },
            { ShipmentOptions.FedEx, () => new ShipmentCalculatorFedEx() },
        };

        public static IShipmentCalculator CreateCalculator(ShipmentOptions shipmentOptions)
        {
            if (!_shipmentOptionCalculatorPairs.ContainsKey(shipmentOptions))
            {
                throw new ArgumentOutOfRangeException(nameof(shipmentOptions));
            }

            return _shipmentOptionCalculatorPairs[shipmentOptions]();
        }
    }
}

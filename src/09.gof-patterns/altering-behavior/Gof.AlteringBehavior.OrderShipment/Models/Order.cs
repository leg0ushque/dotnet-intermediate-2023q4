using Gof.AlteringBehavior.OrderShipment.Models.Enums;

namespace Gof.AlteringBehavior.OrderShipment.Models
{
    public class Order
    {
        public double Weight { get; }

        public ProductType Product { get; }

        public ShipmentOptions ShipmentOptions { get; }

        public Order(ShipmentOptions shipmentOptions, double weight, ProductType product)
        {
            ShipmentOptions = shipmentOptions;
            Product = product;
            Weight = weight;
        }
    }
}

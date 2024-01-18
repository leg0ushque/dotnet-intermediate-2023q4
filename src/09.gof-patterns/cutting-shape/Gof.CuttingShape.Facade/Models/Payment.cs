namespace Gof.CuttingShape.Facade.Models
{
    public class Payment
    {
        public int Quantity { get; set; }

        public Product Product { get; set; }

        public decimal Cost => Quantity * Product.Price;
    }
}

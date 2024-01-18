using Gof.CuttingShape.Facade.Models;

namespace Gof.CuttingShape.Facade.Services
{
    public class ProductCatalog : IProductCatalog
    {
        private readonly IEnumerable<Product> _items;

        public ProductCatalog(IEnumerable<Product> items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        public Product GetProductDetails(string productId)
        {
            return _items.FirstOrDefault(product => product.Id == productId);
        }
    }
}
using Gof.CuttingShape.Facade.Models;

namespace Gof.CuttingShape.Facade.Services
{
    public interface IProductCatalog
    {
        Product GetProductDetails(string productId);
    }
}
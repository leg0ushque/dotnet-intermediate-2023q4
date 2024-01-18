using Gof.CuttingShape.Facade.Models;

namespace Gof.CuttingShape.Facade.Services
{
    public interface IInvoiceSystem
    {
        void SendInvoice(Invoice invoice);
    }
}
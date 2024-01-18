using Gof.CuttingShape.Facade.Models;

namespace Gof.CuttingShape.Facade.Services
{
    public class ConsoleInvoiceSystem : IInvoiceSystem
    {
        public void SendInvoice(Invoice invoice)
        {
            var payment = invoice.Payment;
            var product = payment.Product;

            Console.WriteLine($"Invoice for Product payment");
            Console.WriteLine($"Product: {product.Name} (ID: {product.Id})");
            Console.WriteLine($"Cost: {payment.Cost}");
            Console.WriteLine($"Invoice was sent to email: {invoice.Email}");
        }
    }
}
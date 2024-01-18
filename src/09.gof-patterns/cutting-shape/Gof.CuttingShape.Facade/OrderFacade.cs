using Gof.CuttingShape.Facade.Models;
using Gof.CuttingShape.Facade.Services;

namespace Gof.CuttingShape.Facade
{
    public class OrderFacade
    {
        private readonly IInvoiceSystem _invoiceSystem;
        private readonly IPaymentSystem _paymentSystem;
        private readonly IProductCatalog _productCatalog;

        public OrderFacade(IInvoiceSystem invoiceSystem,
            IPaymentSystem paymentSystem,
            IProductCatalog productCatalog)
        {
            _invoiceSystem = invoiceSystem ?? throw new ArgumentNullException(nameof(invoiceSystem));
            _paymentSystem = paymentSystem ?? throw new ArgumentNullException(nameof(paymentSystem));
            _productCatalog = productCatalog ?? throw new ArgumentNullException(nameof(productCatalog));
        }

        public void PlaceOrder(string productId, int quantity, string email)
        {
            ValidateOrder(productId, quantity, email);

            var product = _productCatalog.GetProductDetails(productId);

            if (product is null)
            {
                throw new InvalidOperationException("Product not found");
            }

            var payment = new Payment
            {
                Quantity = quantity,
                Product = product,
            };

            if (!_paymentSystem.MakePayment(payment))
            {
                throw new InvalidOperationException("The payment failed");
            }

            _invoiceSystem.SendInvoice(new Invoice
            {
                Email = email,
                Payment = payment,
            });
        }

        private void ValidateOrder(string productId, int cost, string email)
        {
            if (string.IsNullOrEmpty(productId))
            {
                throw new ArgumentException($"{nameof(productId)} is invalid");
            }

            if (cost <= default(int))
            {
                throw new ArgumentOutOfRangeException($"{nameof(cost)}");
            }

            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException($"{nameof(email)} is invalid");
            }
        }
    }
}

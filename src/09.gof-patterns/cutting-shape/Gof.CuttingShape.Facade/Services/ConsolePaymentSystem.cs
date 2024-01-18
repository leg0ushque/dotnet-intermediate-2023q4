using Gof.CuttingShape.Facade.Models;

namespace Gof.CuttingShape.Facade.Services
{
    public class ConsolePaymentSystem : IPaymentSystem
    {
        public bool MakePayment(Payment payment)
        {
            Console.WriteLine($"Payment making was called for {payment.Product.Name} with total cost {payment.Cost}.");

            return true;
        }
    }
}
using Gof.CuttingShape.Facade.Models;

namespace Gof.CuttingShape.Facade.Services
{
    public interface IPaymentSystem
    {
        bool MakePayment(Payment payment);
    }
}
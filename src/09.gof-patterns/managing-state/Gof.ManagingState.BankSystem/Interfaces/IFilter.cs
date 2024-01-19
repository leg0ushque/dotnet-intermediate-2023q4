using Gof.ManagingState.BankSystem.Models;

namespace Gof.ManagingState.BankSystem.Interfaces
{
    public interface IFilter
    {
        IEnumerable<Trade> Match(IEnumerable<Trade> trades);
    }
}

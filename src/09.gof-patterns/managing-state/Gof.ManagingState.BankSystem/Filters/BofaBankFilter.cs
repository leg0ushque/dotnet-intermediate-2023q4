using Gof.ManagingState.BankSystem.Models;
using Gof.ManagingState.BankSystem.Interfaces;

namespace Gof.ManagingState.BankSystem.Filters
{
    public class BofaBankFilter : IFilter
    {
        private const int MinAmount = 70;

        public IEnumerable<Trade> Match(IEnumerable<Trade> trades)
        {
            return trades.Where(trade => trade.Amount > MinAmount);
        }
    }
}

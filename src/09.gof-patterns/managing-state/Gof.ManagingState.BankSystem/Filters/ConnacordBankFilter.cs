using Gof.ManagingState.BankSystem.Models;
using Gof.ManagingState.BankSystem.Interfaces;
using Gof.ManagingState.BankSystem.Models.Enums;

namespace Gof.ManagingState.BankSystem.Filters
{
    public class ConnacordBankFilter : IFilter
    {
        private const int MinAmount = 10;
        private const int MaxAmount = 40;

        public IEnumerable<Trade> Match(IEnumerable<Trade> trades)
        {
            return trades.Where(trade => trade.Type == TradeType.Future
                && trade.Amount > MinAmount
                && trade.Amount < MaxAmount);
        }
    }
}

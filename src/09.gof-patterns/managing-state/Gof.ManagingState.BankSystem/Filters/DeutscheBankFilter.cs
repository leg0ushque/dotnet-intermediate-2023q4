using Gof.ManagingState.BankSystem.Models;
using Gof.ManagingState.BankSystem.Interfaces;
using Gof.ManagingState.BankSystem.Models.Enums;

namespace Gof.ManagingState.BankSystem.Filters
{
    public class DeutscheBankFilter : IFilter
    {
        private const int MinAmount = 90;
        private const int MaxAmount = 120;

        public IEnumerable<Trade> Match(IEnumerable<Trade> trades)
        {
            return trades.Where(trade => trade.Type == TradeType.Option
                && trade.Subtype == TradeSubType.NyOption
                && trade.Amount > MinAmount
                && trade.Amount < MaxAmount);
        }
    }
}

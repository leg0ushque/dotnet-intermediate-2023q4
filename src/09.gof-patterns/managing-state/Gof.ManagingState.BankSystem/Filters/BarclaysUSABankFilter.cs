using Gof.ManagingState.BankSystem.Models;
using Gof.ManagingState.BankSystem.Interfaces;
using Gof.ManagingState.BankSystem.Models.Enums;

namespace Gof.ManagingState.BankSystem.Filters
{
    public class BarclaysUSABankFilter : IFilter
    {
        private const int MinAmount = 50;

        public IEnumerable<Trade> Match(IEnumerable<Trade> trades)
        {
            return trades.Where(trade => trade.Type == TradeType.Option
                && trade.Subtype == TradeSubType.NyOption
                && trade.Amount > MinAmount);
        }
    }
}

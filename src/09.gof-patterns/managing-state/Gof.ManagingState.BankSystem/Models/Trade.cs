using Gof.ManagingState.BankSystem.Models.Enums;

namespace Gof.ManagingState.BankSystem.Models
{
    public class Trade
    {
        public decimal Amount { get; set; }

        public TradeType Type { get; set; }

        public TradeSubType Subtype { get; set; }
    }
}

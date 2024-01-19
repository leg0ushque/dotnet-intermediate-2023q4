using Gof.ManagingState.BankSystem.Models;
using Gof.ManagingState.BankSystem.Models.Enums;
using Gof.ManagingState.BankSystem.Factories;

namespace Gof.ManagingState.BankSystem.Extensions
{

    public static class TradeFilter
    {
        public static IEnumerable<Trade> FilterForBank(this IEnumerable<Trade> trades, Bank bank, string country = null)
        {
            var bankFilter = TradeFilterFactory.CreateFilter(bank, country);

            return bankFilter.Match(trades);
        }
    }
}

using Gof.ManagingState.BankSystem.Filters;
using Gof.ManagingState.BankSystem.Interfaces;
using Gof.ManagingState.BankSystem.Models.Enums;

namespace Gof.ManagingState.BankSystem.Factories
{
    public static class TradeFilterFactory
    {
        private const string USA = nameof(USA);

        private const string England = nameof(England);

        private static readonly Dictionary<(Bank, string), Func<IFilter>> _tradeFilterFactories = new()
        {
            { (Bank.Bofa, string.Empty), () => new BofaBankFilter() },
            { (Bank.Connacord, string.Empty), () => new ConnacordBankFilter() },
            { (Bank.Barclays, USA), () => new BarclaysUSABankFilter() },
            { (Bank.Barclays, England), () => new BarclaysEnglandBankFilter() },
            { (Bank.Deutsche, string.Empty), () => new DeutscheBankFilter() },
        };

        public static IFilter CreateFilter(Bank bank, string country = null)
        {
            country ??= string.Empty;
            var tradeFilterKey = (bank, country);

            if (!_tradeFilterFactories.ContainsKey(tradeFilterKey))
            {
                throw new ArgumentOutOfRangeException(nameof(bank), "Unsupported bank");
            }

            return _tradeFilterFactories[tradeFilterKey].Invoke();
        }
    }
}

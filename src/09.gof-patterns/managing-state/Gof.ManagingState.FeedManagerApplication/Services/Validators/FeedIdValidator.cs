using Gof.ManagingState.FeedManagerApplication.Models;
using Gof.ManagingState.FeedManagerApplication.Models.Validation;
using Gof.ManagingState.FeedManagerApplication.Interfaces;


namespace Gof.ManagingState.FeedManagerApplication.Services.Validators
{
    public class FeedIdValidator<T> : IFeedValidator<T>
        where T : TradeFeed
    {
        private const int MinIdValue = 1;

        public ValidationResult Validate(T feed)
        {
            var validationResult = ValidationResult.CreateSuccessful();
            var idInfoCollection = new[]
            {
                new { PropertyName = nameof(TradeFeed.StagingId), GetValue = new Func<T, int>(trade => trade.StagingId) },
                new { PropertyName = nameof(TradeFeed.CounterpartyId), GetValue = new Func<T, int>(trade => trade.CounterpartyId) },
                new { PropertyName = nameof(TradeFeed.PrincipalId), GetValue = new Func<T, int>(trade => trade.PrincipalId) },
                new { PropertyName = nameof(TradeFeed.SourceAccountId), GetValue = new Func<T, int>(trade => trade.SourceAccountId.GetValueOrDefault()) },
            };

            foreach (var idInfo in idInfoCollection)
            {
                if (idInfo.GetValue(feed) < MinIdValue)
                {
                    validationResult.AddError($"IncorrectIdValue:{idInfo.PropertyName}");
                }
            }

            return validationResult;
        }
    }
}

using Gof.ManagingState.FeedManagerApplication.Models;
using Gof.ManagingState.FeedManagerApplication.Models.Validation;
using Gof.ManagingState.FeedManagerApplication.Interfaces;


namespace Gof.ManagingState.FeedManagerApplication.Services.Validators
{
    public class FeedPriceValidator<T> : IFeedValidator<T>
        where T : TradeFeed
    {
        private const int MultiplicationValue = 100;

        public ValidationResult Validate(T feed)
        {
            var remainderValue = (feed.CurrentPrice * MultiplicationValue) - (int)(feed.CurrentPrice * MultiplicationValue);

            if (remainderValue != decimal.Zero)
            {
                return ValidationResult.CreateFailed($"PriceIsInvalid: {feed.CurrentPrice}");
            }

            return ValidationResult.CreateSuccessful();
        }
    }
}

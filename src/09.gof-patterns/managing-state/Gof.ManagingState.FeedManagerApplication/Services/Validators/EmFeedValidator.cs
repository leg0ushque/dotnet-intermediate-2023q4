using Gof.ManagingState.FeedManagerApplication.Models;
using Gof.ManagingState.FeedManagerApplication.Models.Validation;
using Gof.ManagingState.FeedManagerApplication.Interfaces;

namespace Gof.ManagingState.FeedManagerApplication.Services.Validators
{
    public class EmFeedValidator : IFeedValidator<EmFeed>
    {
        private const int MinValue = 0;
        private const int SedolMaxValue = 100;

        public ValidationResult Validate(EmFeed feed)
        {
            var validationResult = ValidationResult.CreateSuccessful();

            if (feed.Sedol <= MinValue || feed.Sedol >= SedolMaxValue)
            {
                validationResult.AddError($"IncorrectSedol: {feed.Sedol}");
            }

            if (feed.AssetValue <= MinValue || feed.AssetValue >= feed.Sedol)
            {
                validationResult.AddError($"IncorrectAssetValue: {feed.AssetValue}");
            }

            return validationResult;
        }
    }
}

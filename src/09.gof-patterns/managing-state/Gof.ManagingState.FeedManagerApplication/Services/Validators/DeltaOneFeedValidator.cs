using System.Text.RegularExpressions;
using Gof.ManagingState.FeedManagerApplication.Models;
using Gof.ManagingState.FeedManagerApplication.Models.Validation;
using Gof.ManagingState.FeedManagerApplication.Interfaces;

namespace Gof.ManagingState.FeedManagerApplication.Services.Validators
{
    public class DeltaOneFeedValidator : IFeedValidator<DeltaOneFeed>
    {
        private const string ValidationPattern = @"^[A-Z]{2}\d{10}$";

        public ValidationResult Validate(DeltaOneFeed feed)
        {
            var validationResult = ValidationResult.CreateSuccessful();

            if (!Regex.IsMatch(feed.Isin, ValidationPattern))
            {
                validationResult.AddError($"IncorrectIsin: {feed.Isin}");
            }

            if (feed.MaturityDate <= feed.ValuationDate)
            {
                validationResult.AddError($"Maturity date isn't bigger than valuation date");
            }

            return validationResult;
        }
    }

}

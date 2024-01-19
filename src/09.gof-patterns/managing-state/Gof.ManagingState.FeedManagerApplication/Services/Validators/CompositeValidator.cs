using Gof.ManagingState.FeedManagerApplication.Models;
using Gof.ManagingState.FeedManagerApplication.Models.Validation;
using Gof.ManagingState.FeedManagerApplication.Interfaces;

namespace Gof.ManagingState.FeedManagerApplication.Services.Validators
{
    public class CompositeValidator<T> : IFeedValidator<T>
        where T : TradeFeed
    {
        private readonly IEnumerable<IFeedValidator<T>> _feedValidators;

        public CompositeValidator(IEnumerable<IFeedValidator<T>> feedValidators)
        {
            _feedValidators = feedValidators;
        }

        public ValidationResult Validate(T feed)
        {
            var validationResuls = _feedValidators
                .Select(validator => validator.Validate(feed))
                .ToArray();

            if (validationResuls.All(result => result.IsValid))
            {
                return ValidationResult.CreateSuccessful();
            }

            var errorMessages = validationResuls
                .SelectMany(result => result.ErrorMessages)
                .ToArray();

            return ValidationResult.CreateFailed(errorMessages);
        }
    }
}

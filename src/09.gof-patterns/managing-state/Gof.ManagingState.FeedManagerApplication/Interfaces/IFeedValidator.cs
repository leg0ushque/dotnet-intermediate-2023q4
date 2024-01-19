using Gof.ManagingState.FeedManagerApplication.Models;
using Gof.ManagingState.FeedManagerApplication.Models.Validation;

namespace Gof.ManagingState.FeedManagerApplication.Interfaces
{
    public interface IFeedValidator<T>
        where T : TradeFeed
    {
        ValidationResult Validate(T feed);
    }
}

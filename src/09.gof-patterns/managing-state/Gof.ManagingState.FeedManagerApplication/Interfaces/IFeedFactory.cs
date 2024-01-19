using Gof.ManagingState.FeedManagerApplication.Models;

namespace Gof.ManagingState.FeedManagerApplication.Interfaces
{
    public interface IFeedFactory<T>
        where T : TradeFeed
    {
        IFeedValidator<T> CreateValidator();

        IFeedMatcher<T> CreateMatcher();

        IDatabaseRepository<T> CreateRepository();
    }
}

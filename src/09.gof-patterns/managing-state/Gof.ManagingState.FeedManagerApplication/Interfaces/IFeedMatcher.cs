using Gof.ManagingState.FeedManagerApplication.Models;

namespace Gof.ManagingState.FeedManagerApplication.Interfaces
{
    public interface IFeedMatcher<T>
        where T : TradeFeed
    {
        bool Match(T current, T other);
    }
}

using Gof.ManagingState.FeedManagerApplication.Models;
using Gof.ManagingState.FeedManagerApplication.Interfaces;

namespace Gof.ManagingState.FeedManagerApplication.Factories
{
    public static class TradeFeedFactory
    {
        public static IFeedFactory<T> CreateFeedFactory<T>()
            where T : TradeFeed
        {
            if (typeof(T) == typeof(DeltaOneFeed))
            {
                return (IFeedFactory<T>)(new DeltaOneFeedFactory());
            }
            else if (typeof(T) == typeof(EmFeed))
            {
                return (IFeedFactory<T>)(new EmFeedFactory());
            }

            throw new ArgumentException(typeof(T).FullName);
        }
    }
}

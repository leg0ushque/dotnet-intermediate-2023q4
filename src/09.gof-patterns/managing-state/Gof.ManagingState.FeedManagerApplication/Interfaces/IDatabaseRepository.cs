using Gof.ManagingState.FeedManagerApplication.Models;

namespace Gof.ManagingState.FeedManagerApplication.Interfaces
{
    public interface IDatabaseRepository<T>
        where T : TradeFeed
    {
        List<T> LoadFeeds();

        void SaveFeed(T feed);

        void SaveErrors(int feedStagingId, IEnumerable<string> errorMessages);
    }
}

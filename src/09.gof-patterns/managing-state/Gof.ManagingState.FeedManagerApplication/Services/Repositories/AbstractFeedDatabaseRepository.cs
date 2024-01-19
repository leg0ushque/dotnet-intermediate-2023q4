using Gof.ManagingState.FeedManagerApplication.Models;
using Gof.ManagingState.FeedManagerApplication.Interfaces;

namespace Gof.ManagingState.FeedManagerApplication.Services.Repositories
{
    public abstract class AbstractFeedDatabaseRepository<T> : IDatabaseRepository<T>
        where T : TradeFeed
    {
        public abstract List<T> LoadFeeds();

        public void SaveErrors(int feedStagingId, IEnumerable<string> errorMessages)
        {
            Console.WriteLine();
            Console.WriteLine($"Incorrect {nameof(feedStagingId)}:\t{feedStagingId}");
            foreach (var errorMessage in errorMessages)
            {
                Console.WriteLine($"\t{errorMessage}");
            }
        }

        public virtual void SaveFeed(T feed)
        {
            Console.WriteLine();
            Console.WriteLine($"Saving {typeof(T).Name}:");
            Console.WriteLine($"\t{nameof(TradeFeed.StagingId)}: {feed.StagingId}");
            Console.WriteLine($"\t{nameof(TradeFeed.SourceTradeRef)}: {feed.SourceTradeRef}");
            Console.WriteLine($"\t{nameof(TradeFeed.CounterpartyId)}: {feed.CounterpartyId}");
            Console.WriteLine($"\t{nameof(TradeFeed.PrincipalId)}: {feed.PrincipalId}");
            Console.WriteLine($"\t{nameof(TradeFeed.ValuationDate)}: {feed.ValuationDate}");
            Console.WriteLine($"\t{nameof(TradeFeed.CurrentPrice)}: {feed.CurrentPrice}");
            Console.WriteLine($"\t{nameof(TradeFeed.SourceAccountId)}: {feed.SourceAccountId}");
        }
    }
}

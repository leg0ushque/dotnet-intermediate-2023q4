using Gof.ManagingState.FeedManagerApplication.Models;

namespace Gof.ManagingState.FeedManagerApplication.Services.Repositories
{
    public class DeltaOneFeedDatabaseRepository : AbstractFeedDatabaseRepository<DeltaOneFeed>
    {
        public override List<DeltaOneFeed> LoadFeeds()
        {
            return new List<DeltaOneFeed>
            {
                new DeltaOneFeed { CounterpartyId = 3, PrincipalId = 3 },
            };
        }

        public override void SaveFeed(DeltaOneFeed feed)
        {
            base.SaveFeed(feed);

            Console.WriteLine($"\t{nameof(DeltaOneFeed.Isin)}: {feed.Isin}");
            Console.WriteLine($"\t{nameof(DeltaOneFeed.MaturityDate)}: {feed.MaturityDate}");
        }
    }

}

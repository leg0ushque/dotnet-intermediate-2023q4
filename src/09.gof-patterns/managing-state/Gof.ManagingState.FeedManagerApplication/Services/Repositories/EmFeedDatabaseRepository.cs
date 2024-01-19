using Gof.ManagingState.FeedManagerApplication.Models;

namespace Gof.ManagingState.FeedManagerApplication.Services.Repositories
{
    public class EmFeedDatabaseRepository : AbstractFeedDatabaseRepository<EmFeed>
    {
        public override List<EmFeed> LoadFeeds()
        {
            return new List<EmFeed>
            {
                new EmFeed { StagingId = 3, SourceAccountId = 4 },
            };
        }

        public override void SaveFeed(EmFeed feed)
        {
            base.SaveFeed(feed);

            Console.WriteLine($"\t{nameof(EmFeed.Sedol)}: {feed.Sedol}");
            Console.WriteLine($"\t{nameof(EmFeed.AssetValue)}: {feed.AssetValue}");
        }
    }

}

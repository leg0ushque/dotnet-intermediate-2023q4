using Gof.ManagingState.FeedManagerApplication.Models;
using Gof.ManagingState.FeedManagerApplication.Interfaces;
using Gof.ManagingState.FeedManagerApplication.Services.Repositories;
using Gof.ManagingState.FeedManagerApplication.Services.Validators;
using Gof.ManagingState.FeedManagerApplication.Services.Matchers;

namespace Gof.ManagingState.FeedManagerApplication.Factories
{
    public class DeltaOneFeedFactory : IFeedFactory<DeltaOneFeed>
    {
        public IFeedMatcher<DeltaOneFeed> CreateMatcher()
        {
            return new DeltaOneFeedMatcher();
        }

        public IFeedValidator<DeltaOneFeed> CreateValidator()
        {
            return new CompositeValidator<DeltaOneFeed>(new IFeedValidator<DeltaOneFeed>[]
            {
                new FeedIdValidator<DeltaOneFeed>(),
                new FeedPriceValidator<DeltaOneFeed>(),
                new DeltaOneFeedValidator(),
            });
        }

        public IDatabaseRepository<DeltaOneFeed> CreateRepository()
        {
            return new DeltaOneFeedDatabaseRepository();
        }
    }
}

using Gof.ManagingState.FeedManagerApplication.Models;
using Gof.ManagingState.FeedManagerApplication.Interfaces;
using Gof.ManagingState.FeedManagerApplication.Services.Repositories;
using Gof.ManagingState.FeedManagerApplication.Services.Validators;
using Gof.ManagingState.FeedManagerApplication.Services.Matchers;

namespace Gof.ManagingState.FeedManagerApplication.Factories
{

    public class EmFeedFactory : IFeedFactory<EmFeed>
    {
        public IFeedMatcher<EmFeed> CreateMatcher()
        {
            return new EmFeedMatcher();
        }

        public IFeedValidator<EmFeed> CreateValidator()
        {
            return new CompositeValidator<EmFeed>(new IFeedValidator<EmFeed>[]
            {
                new FeedIdValidator<EmFeed>(),
                new FeedPriceValidator<EmFeed>(),
                new EmFeedValidator(),
            });
        }

        public IDatabaseRepository<EmFeed> CreateRepository()
        {
            return new EmFeedDatabaseRepository();
        }
    }
}

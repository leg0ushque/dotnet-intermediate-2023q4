using Gof.ManagingState.FeedManagerApplication.Models;
using Gof.ManagingState.FeedManagerApplication.Interfaces;

namespace Gof.ManagingState.FeedManagerApplication.Services
{
    public class FeedImporterFacade<T>
        where T : TradeFeed
    {
        private readonly IFeedMatcher<T> _feedMatcher;
        private readonly IFeedValidator<T> _feedValidator;
        private readonly IDatabaseRepository<T> _databaseRepository;

        public FeedImporterFacade(IFeedFactory<T> feedFactory)
        {
            _feedMatcher = feedFactory.CreateMatcher();
            _feedValidator = feedFactory.CreateValidator();
            _databaseRepository = feedFactory.CreateRepository();
        }

        public void Import(IEnumerable<T> feeds)
        {
            var validationInfoCollection = feeds.Select(feed => new
            {
                Feed = feed,
                Result = _feedValidator.Validate(feed)
            })
            .ToArray();

            foreach (var validationInfo in validationInfoCollection.Where(validationInfo => !validationInfo.Result.IsValid))
            {
                _databaseRepository.SaveErrors(validationInfo.Feed.StagingId, validationInfo.Result.ErrorMessages);
            }

            var dbFeedCollection = _databaseRepository.LoadFeeds();
            var validFeedCollection = validationInfoCollection
                .Where(validationInfo => validationInfo.Result.IsValid)
                .Select(validationInfo => validationInfo.Feed)
                .ToArray();

            var newValidFeedCollection = validFeedCollection
                .Where(validFeed => !dbFeedCollection.Any(feed => _feedMatcher.Match(validFeed, feed)))
                .ToArray();

            Array.ForEach(newValidFeedCollection, _databaseRepository.SaveFeed);
        }
    }

}

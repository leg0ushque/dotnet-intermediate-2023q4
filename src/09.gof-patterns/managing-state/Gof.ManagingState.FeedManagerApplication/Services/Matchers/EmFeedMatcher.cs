using Gof.ManagingState.FeedManagerApplication.Models;
using Gof.ManagingState.FeedManagerApplication.Interfaces;

namespace Gof.ManagingState.FeedManagerApplication.Services.Matchers
{
    public class EmFeedMatcher : IFeedMatcher<EmFeed>
    {
        public bool Match(EmFeed current, EmFeed other)
        {
            return (current.SourceAccountId.HasValue && other.SourceAccountId.HasValue)
                ? current.SourceAccountId == other.SourceAccountId
                : current.StagingId == current.StagingId;
        }
    }
}

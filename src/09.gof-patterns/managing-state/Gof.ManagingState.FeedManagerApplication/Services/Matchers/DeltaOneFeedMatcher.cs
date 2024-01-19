using Gof.ManagingState.FeedManagerApplication.Models;
using Gof.ManagingState.FeedManagerApplication.Interfaces;

namespace Gof.ManagingState.FeedManagerApplication.Services.Matchers
{
    public class DeltaOneFeedMatcher : IFeedMatcher<DeltaOneFeed>
    {
        public bool Match(DeltaOneFeed current, DeltaOneFeed other)
        {
            return current.CounterpartyId == other.CounterpartyId
                && current.PrincipalId == other.PrincipalId;
        }
    }

}

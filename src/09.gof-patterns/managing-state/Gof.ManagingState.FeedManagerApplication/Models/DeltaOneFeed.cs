namespace Gof.ManagingState.FeedManagerApplication.Models
{
    public class DeltaOneFeed : TradeFeed
    {
        public string Isin { get; set; }

        public DateTime MaturityDate { get; set; }
    }
}

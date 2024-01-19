namespace Gof.ManagingState.FeedManagerApplication.Models
{
    public class EmFeed : TradeFeed
    {
        public decimal Sedol { get; set; }

        public decimal AssetValue { get; set; }
    }
}

namespace Gof.ManagingState.FeedManagerApplication.Models
{
    public class TradeFeed
    {
        public int StagingId { get; set; }

        public int SourceTradeRef { get; set; }

        public int CounterpartyId { get; set; }

        public int PrincipalId { get; set; }

        public DateTime ValuationDate { get; set; }

        public decimal CurrentPrice { get; set; }

        public int? SourceAccountId { get; set; }
    }
}

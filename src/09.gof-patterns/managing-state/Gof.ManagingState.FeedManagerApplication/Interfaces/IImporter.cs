namespace Gof.ManagingState.FeedManagerApplication.Interfaces
{
    public interface IImporter<T>
    {
        public void Import(IEnumerable<T> feeds);
    }
}

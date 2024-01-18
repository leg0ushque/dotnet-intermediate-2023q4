namespace Gof.CuttingShape.Adapter
{
    public class ElementsCollection<T> : IElements<T>
    {
        public ElementsCollection(IEnumerable<T> items)
        {
            Items = items;
        }

        public IEnumerable<T> Items { get; }

        public IEnumerable<T> GetElements() => Items;
    }
}

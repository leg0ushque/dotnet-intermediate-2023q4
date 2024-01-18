namespace Gof.CuttingShape.Adapter
{
    public interface IElements<T>
    {
        IEnumerable<T> GetElements();
    }
}
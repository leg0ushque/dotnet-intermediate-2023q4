namespace Gof.CuttingShape.Composite
{
    public interface IXmlComponent
    {
        bool IsComposite { get; }

        void AddChildComponent(IXmlComponent xmlComponent);

        string ToXmlString();
    }
}
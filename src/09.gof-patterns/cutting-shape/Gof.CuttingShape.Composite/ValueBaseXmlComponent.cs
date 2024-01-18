namespace Gof.CuttingShape.Composite
{
    public abstract class ValueBaseXmlComponent : BaseXmlComponent
    {
        protected readonly string _value;

        protected ValueBaseXmlComponent(string value, bool isComposite, int offset = default, IEnumerable<IXmlComponent> children = null)
            : base(isComposite, offset, children)
        {
            _value = value;
        }
    }
}

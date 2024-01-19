namespace Gof.CuttingShape.Composite
{
    public abstract class BaseXmlComponent : IXmlComponent
    {
        protected readonly int _offset;

        public bool IsComposite { get; }

        protected List<IXmlComponent> Children { get; }

        protected BaseXmlComponent(bool isComposite, int offset = default, IEnumerable<IXmlComponent> children = null)
        {
            _offset = offset;
            IsComposite = isComposite;

            if (isComposite)
            {
                Children = children is null
                    ? new List<IXmlComponent>()
                    : children.ToList();
            }
        }
        protected string Offset => new string('\t', _offset);

        public abstract string ToXmlString();

        public void AddChildComponent(IXmlComponent xmlComponent)
        {
            if (!IsComposite)
            {
                throw new InvalidOperationException("Component can't contain child elements due to it's not composite");
            }

            if (xmlComponent is null)
            {
                throw new ArgumentNullException(nameof(xmlComponent));
            }

            Children.Add(xmlComponent);
        }
    }
}
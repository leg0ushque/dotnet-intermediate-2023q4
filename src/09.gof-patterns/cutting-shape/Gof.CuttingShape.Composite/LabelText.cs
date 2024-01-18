namespace Gof.CuttingShape.Composite
{
    public class LabelText : ValueBaseXmlComponent
    {
        public LabelText(string value, int offset = default)
            : base(value, isComposite: false, offset, null)
        { }

        public override string ToXmlString()
        {
            return $"{Offset}<{nameof(LabelText)} value='{_value}'/>";
        }
    }
}
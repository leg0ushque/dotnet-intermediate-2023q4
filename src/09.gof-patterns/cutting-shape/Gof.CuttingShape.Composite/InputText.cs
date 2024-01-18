namespace Gof.CuttingShape.Composite
{
    public class InputText : ValueBaseXmlComponent
    {
        private readonly string _name;

        public InputText(string name, string value, int offset = default)
            : base(value, isComposite: false, offset, null)
        {
            _name = name;
        }

        public override string ToXmlString()
        {
            return $"{Offset}<{nameof(InputText)} name='{_name}' value='{_value}'/>";
        }
    }
}
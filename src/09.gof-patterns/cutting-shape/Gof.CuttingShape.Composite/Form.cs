using System.Text;

namespace Gof.CuttingShape.Composite
{
    public class Form : BaseXmlComponent
    {
        private readonly string _name;

        public Form(string name, int offset = default, IEnumerable<IXmlComponent> xmlComponents = null)
            : base(isComposite: true, offset, xmlComponents)
        {
            _name = name;
        }

        public override string ToXmlString()
        {
            var xmlBuilder = new StringBuilder();

            xmlBuilder.AppendLine($"{Offset}<{nameof(Form)} name='{_name}'>");
            xmlBuilder.AppendLine(string.Join("\n", Children.Select(x => x.ToXmlString())));
            xmlBuilder.Append($"{Offset}</{nameof(Form)}>");

            return xmlBuilder.ToString();
        }
    }
}
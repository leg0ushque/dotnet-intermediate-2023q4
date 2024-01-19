namespace Gof.CuttingShape.Adapter
{
    public class Document
    {
        public string Name { get; set; }

        public override string ToString() => $"A document with name {Name}";
    }
}

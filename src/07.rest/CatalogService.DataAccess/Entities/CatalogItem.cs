namespace CatalogService.DataAccess.Entities
{
    public class CatalogItem : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }
    }
}

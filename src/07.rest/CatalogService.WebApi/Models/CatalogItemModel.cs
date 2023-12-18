namespace CatalogService.WebApi.Models
{
    public class CatalogItemModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }
    }
}

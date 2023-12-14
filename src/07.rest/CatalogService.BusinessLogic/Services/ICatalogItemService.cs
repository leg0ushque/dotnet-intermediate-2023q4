using CatalogService.BusinessLogic.Dtos;

namespace CatalogService.BusinessLogic.Services
{
    public interface ICatalogItemService : IService<CatalogItemDto>
    {
        public Task<IReadOnlyCollection<CatalogItemDto>> GetAllByCategoryAsync(
            int? categoryId = null,
            int? pageNumber = null,
            int? pageSize = null,
            CancellationToken cancellationToken = default);
        public Task DeleteAllByCategoryAsync(int? categoryId = null, CancellationToken cancellationToken = default);
    }
}
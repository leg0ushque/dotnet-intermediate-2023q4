namespace CatalogService.BusinessLogic.Services
{
    public interface IService<TEntityDto>
    {
        Task<int> CreateAsync(TEntityDto entity, CancellationToken cancellationToken = default);

        Task<IReadOnlyCollection<TEntityDto>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<TEntityDto> GetById(int entityId, CancellationToken cancellationToken = default);

        Task UpdateAsync(TEntityDto entity, CancellationToken cancellationToken = default);

        Task DeleteAsync(int entityId, CancellationToken cancellationToken = default);
    }
}

using AutoMapper;
using CatalogService.BusinessLogic.Dtos;
using CatalogService.BusinessLogic.Helpers;
using CatalogService.BusinessLogic.Validators;
using CatalogService.DataAccess.Entities;
using CatalogService.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.BusinessLogic.Services
{
    public class CatalogItemService : GenericEntityService<CatalogItem, CatalogItemDto>, ICatalogItemService
    {
        public CatalogItemService(IValidator<CatalogItemDto> validator,
            IRepository<CatalogItem> repository, IMapper mapper)
            : base(validator, repository, mapper)
        { }

        public async Task<IReadOnlyCollection<CatalogItemDto>> GetAllByCategoryAsync(int? categoryId = null,
            int? pageNumber = null, int? pageSize = null, CancellationToken cancellationToken = default)
        {
            var allItems = _repository.GetAll();

            return _mapper.Map<List<CatalogItemDto>>(
                    await PaginationHelper<CatalogItem>.GetPage(
                        categoryId is null ?
                            allItems
                            : allItems.Where(x => x.CategoryId == categoryId),
                        pageNumber, pageSize, cancellationToken))
                .AsReadOnly();
        }

        public async Task DeleteAllByCategoryAsync(int? categoryId = null, CancellationToken cancellationToken = default)
        {
            var allItems = _repository.GetAll();

            var itemsToDelete = await allItems.Where(x => x.CategoryId == categoryId).ToListAsync(cancellationToken);

            foreach (var item in itemsToDelete)
            {
                await _repository.DeleteAsync(item.Id);
            }
        }
    }
}

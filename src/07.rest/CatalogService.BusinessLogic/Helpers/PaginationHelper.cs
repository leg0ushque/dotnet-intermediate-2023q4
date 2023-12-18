using CatalogService.BusinessLogic.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.BusinessLogic.Helpers
{
    public static class PaginationHelper<T>
        where T : class
    {
        private const int ExtraPage = 1;
        private const int NoExtraPage = 0;

        public static async Task<List<T>> GetPage(IQueryable<T> items, int? pageNumber, int? pageSize, CancellationToken cancellationToken = default)
        {
            pageNumber ??= Constants.MinPageNumber;
            pageSize ??= Constants.DefaultPageSize;

            if (pageSize.Value < Constants.MinPageSize)
            {
                throw new BusinessLogicException($"Page size value should be greater or equal {Constants.MinPageSize}.");
            }

            var itemsCount = items.Count();
            var skipCount = (pageNumber.Value - 1) * pageSize.Value;

            if (skipCount >= itemsCount)
            {
                return Enumerable.Empty<T>().ToList();
            }

            // for 7 items per page:
            // 35 items = 5 pages, 37 items = 6 pages
            var lastPageNumber = itemsCount / pageSize.Value +
                (itemsCount % pageSize.Value == 0 ? NoExtraPage : ExtraPage);

            if (pageNumber < Constants.MinPageNumber || pageNumber.Value > lastPageNumber)
            {
                throw new BusinessLogicException($"Page number value should be between {Constants.MinPageNumber} and {lastPageNumber} for size of {pageSize.Value} items per page.");
            }

            return await items.Skip(skipCount).Take(pageSize.Value).ToListAsync(cancellationToken);
        }
    }
}

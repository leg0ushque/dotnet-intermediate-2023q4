using CatalogService.BusinessLogic.Dtos;
using CatalogService.BusinessLogic.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace CatalogService.BusinessLogic.Validators
{
    public class CatalogItemValidator : IValidator<CatalogItemDto>
    {
        public Task Validate(CatalogItemDto entity, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(entity.Name))
            {
                throw new BusinessLogicException("Name should not be null or empty!");
            }

            return Task.CompletedTask;
        }
    }
}

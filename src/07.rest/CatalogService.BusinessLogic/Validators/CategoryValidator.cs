using CatalogService.BusinessLogic.Dtos;
using CatalogService.BusinessLogic.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace CatalogService.BusinessLogic.Validators
{
    public class CategoryValidator : IValidator<CategoryDto>
    {
        public Task Validate(CategoryDto entity, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(entity.Name))
            {
                throw new BusinessLogicException("Name should not be null or empty!");
            }

            return Task.CompletedTask;
        }
    }
}

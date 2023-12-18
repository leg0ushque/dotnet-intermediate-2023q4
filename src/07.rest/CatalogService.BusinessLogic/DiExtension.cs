using CatalogService.BusinessLogic.Dtos;
using CatalogService.BusinessLogic.Services;
using CatalogService.BusinessLogic.Validators;
using CatalogService.DataAccess;
using CatalogService.DataAccess.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogService.BusinessLogic
{
    public static class DiExtension
    {
        public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services, string connectionString)
        {
            return services
                .AddDataAccessServices(connectionString)

                .AddTransient<IValidator<CatalogItemDto>, CatalogItemValidator>()
                .AddTransient<IValidator<CategoryDto>, CategoryValidator>()

                .AddTransient<IService<CatalogItemDto>, GenericEntityService<CatalogItem, CatalogItemDto>>()
                .AddTransient<IService<CategoryDto>, GenericEntityService<Category, CategoryDto>>()

                .AddTransient<ICatalogItemService, CatalogItemService>();
        }
    }
}
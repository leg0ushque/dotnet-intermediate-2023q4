using AutoMapper;
using CatalogService.BusinessLogic.Dtos;
using CatalogService.WebApi.Models;

namespace CatalogService.WebApi.Mapper
{
    public class WebApiMappingProfile : Profile
    {
        public WebApiMappingProfile()
        {
            CreateMap<CatalogItemModel, CatalogItemDto>().ReverseMap();
            CreateMap<CategoryModel, CategoryDto>().ReverseMap();
        }
    }
}

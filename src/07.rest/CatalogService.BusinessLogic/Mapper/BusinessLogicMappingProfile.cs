using AutoMapper;
using CatalogService.BusinessLogic.Dtos;
using CatalogService.DataAccess.Entities;

namespace CatalogService.BusinessLogic.Mapper
{
    public class BusinessLogicMappingProfile : Profile
    {
        public BusinessLogicMappingProfile()
        {
            CreateMap<CatalogItem, CatalogItemDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}

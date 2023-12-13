using AutoMapper;
using CatalogService.BusinessLogic.Dtos;
using CatalogService.BusinessLogic.Services;
using CatalogService.WebApi.Filters;
using CatalogService.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using HttpCode = System.Net.HttpStatusCode;

namespace CatalogService.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogItemsController : ControllerBase
    {
        private IService<CatalogItemDto> _service;
        private readonly IMapper _mapper;

        public CatalogItemsController(IService<CatalogItemDto> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("")]
        [BusinessLogicExceptionFilter(HttpCode.BadRequest, StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CatalogItemModel catalogItem)
        {
            if (catalogItem is null)
            {
                return BadRequest();
            }

            var catalogItemDto = _mapper.Map<CatalogItemDto>(catalogItem);
            var result = await _service.CreateAsync(catalogItemDto);

            return Ok(new { createdId = result });
        }
    }
}
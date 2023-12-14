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
        private readonly ICatalogItemService _service;
        private readonly IMapper _mapper;

        public CatalogItemsController(ICatalogItemService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Create a Catalog item.
        /// </summary>
        /// <param name="catalogItem">Catalog item to create</param>
        /// <returns></returns>
        /// <response code="200">Created item's ID</response>
        /// <response code="400">An error occured while performing the operation</response>
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

        /// <summary>
        /// Update the Catalog item.
        /// </summary>
        /// <param name="catalogItem">Catalog item to update</param>
        /// <returns></returns>
        /// <response code="200">Update was executed successfully</response>
        /// <response code="400">An error occured while performing the operation</response>
        [HttpPut]
        [Route("")]
        [BusinessLogicExceptionFilter(HttpCode.BadRequest, StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(CatalogItemModel catalogItem)
        {
            if (catalogItem is null)
            {
                return BadRequest();
            }

            var catalogItemDto = _mapper.Map<CatalogItemDto>(catalogItem);
            await _service.UpdateAsync(catalogItemDto);

            return Ok();
        }

        /// <summary>
        /// Delete the Catalog item.
        /// </summary>
        /// <param name="itemId">The ID of Catalog item to delete</param>
        /// <returns></returns>
        /// <response code="200">Deletion was executed successfully</response>
        /// <response code="400">An error occured while performing the operation</response>
        [HttpDelete]
        [Route("")]
        [BusinessLogicExceptionFilter(HttpCode.BadRequest, StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int itemId)
        {
            await _service.DeleteAsync(itemId);

            return Ok();
        }

        /// <summary>
        /// Get a list of Catalog item.
        /// </summary>
        /// <param name="categoryId">The ID of  Catalog item to filter by</param>
        /// <param name="pageNumber">Page number to retrieve</param>
        /// <param name="pageSize">The size of page</param>
        /// <returns></returns>
        /// <response code="200">A collection of filtered  Catalog item items</response>
        /// <response code="400">An error occured while performing the operation</response>
        [HttpGet]
        [Route("")]
        [BusinessLogicExceptionFilter(HttpCode.BadRequest, StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll(
            [FromQuery] int? categoryId = null,
            [FromQuery] int? pageNumber = null,
            [FromQuery] int? pageSize = null)
        {
            var items = await _service.GetAllByCategoryAsync(categoryId, pageNumber, pageSize);

            return Ok(items);
        }
    }
}
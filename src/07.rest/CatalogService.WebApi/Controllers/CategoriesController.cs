using AutoMapper;
using CatalogService.BusinessLogic;
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
    public class CategoriesController : ControllerBase
    {
        private readonly IService<CategoryDto> _categoryService;
        private readonly ICatalogItemService _catalogItemService;
        private readonly IMapper _mapper;

        public CategoriesController(
            IService<CategoryDto> categoryService,
            ICatalogItemService catalogItemService,
            IMapper mapper)
        {
            _categoryService = categoryService;
            _catalogItemService = catalogItemService;
            _mapper = mapper;
        }

        /// <summary>
        /// Create a Category.
        /// </summary>
        /// <param name="catalogItem">Category to create</param>
        /// <returns></returns>
        /// <response code="200">Created item's ID</response>
        /// <response code="400">An error occured while performing the operation</response>
        [HttpPost]
        [Route("")]
        [BusinessLogicExceptionFilter(HttpCode.BadRequest, StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CategoryModel category)
        {
            if (category is null)
            {
                return BadRequest();
            }

            var categoryDto = _mapper.Map<CategoryDto>(category);
            var result = await _categoryService.CreateAsync(categoryDto);

            return Ok(new { createdId = result });
        }

        /// <summary>
        /// Update the Category.
        /// </summary>
        /// <param name="catalogItem">Category to update</param>
        /// <returns></returns>
        /// <response code="200">Update was executed successfully</response>
        /// <response code="400">An error occured while performing the operation</response>
        [HttpPut]
        [Route("")]
        [BusinessLogicExceptionFilter(HttpCode.BadRequest, StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(CategoryModel category)
        {
            if (category is null)
            {
                return BadRequest();
            }

            var categoryDto = _mapper.Map<CategoryDto>(category);
            await _categoryService.UpdateAsync(categoryDto);

            return Ok();
        }

        /// <summary>
        /// Delete the Category and all related Catalog items.
        /// </summary>
        /// <param name="itemId">The ID of Category to execute deletion on</param>
        /// <returns></returns>
        /// <response code="200">Deletion was executed successfully</response>
        /// <response code="400">An error occured while performing the operation</response>
        [HttpDelete]
        [Route("")]
        [BusinessLogicExceptionFilter(HttpCode.BadRequest, StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int itemId)
        {
            await _catalogItemService.DeleteAllByCategoryAsync(itemId);

            await _categoryService.DeleteAsync(itemId);

            return Ok();
        }

        /// <summary>
        /// Get a list of Category.
        /// </summary>
        /// <param name="categoryId">The ID of Category to filter by</param>
        /// <param name="pageNumber">Page number to retrieve</param>
        /// <param name="pageSize">The size of page</param>
        /// <returns></returns>
        /// <response code="200">A collection of filtered Category items</response>
        /// <response code="400">An error occured while performing the operation</response>
        [HttpGet]
        [Route("")]
        [BusinessLogicExceptionFilter(HttpCode.BadRequest, StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            var items = await _categoryService.GetAllAsync();

            return Ok(items);
        }
    }
}
using EcommerceAPI.DTOS;
using EcommerceAPI.Helpers;
using EcommerceAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] PaginationParams paginationParams)
        {
            var products = await _productService.GetAllAsync(paginationParams);
            return Ok(ApiResponse<PagedList<ProductResponseDto>>.SuccessResponse(products, "تم جلب المنتجات بنجاح"));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            return Ok(ApiResponse<ProductResponseDto>.SuccessResponse(product, "تم جلب المنتج بنجاح"));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Create(CreateProductDto dto)
        {
            var product = await _productService.CreateAsync(dto);
            return Ok(ApiResponse<ProductResponseDto>.SuccessResponse(product, "تمت إضافة المنتج بنجاح"));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Update(int id, CreateProductDto dto)
        {
            var product = await _productService.UpdateAsync(id, dto);
            return Ok(ApiResponse<ProductResponseDto>.SuccessResponse(product, "تم تعديل المنتج بنجاح"));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            await _productService.DeleteAsync(id);
            return Ok(ApiResponse<string>.SuccessResponse(null, "تم حذف المنتج بنجاح"));
        }
    }
}
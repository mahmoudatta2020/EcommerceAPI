using EcommerceAPI.DTOs;
using EcommerceAPI.Helpers;
using EcommerceAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(ApiResponse<List<CategoryResponseDto>>.SuccessResponse(categories, "تم جلب الكاتيجوريز بنجاح"));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            return Ok(ApiResponse<CategoryResponseDto>.SuccessResponse(category, "تم جلب الكاتيجوري بنجاح"));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Create(CategoryDto dto)
        {
            var category = await _categoryService.CreateAsync(dto);
            return Ok(ApiResponse<CategoryResponseDto>.SuccessResponse(category, "تمت إضافة الكاتيجوري بنجاح"));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Update(int id, CategoryDto dto)
        {
            var category = await _categoryService.UpdateAsync(id, dto);
            return Ok(ApiResponse<CategoryResponseDto>.SuccessResponse(category, "تم تعديل الكاتيجوري بنجاح"));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            await _categoryService.DeleteAsync(id);
            return Ok(ApiResponse<string>.SuccessResponse(null, "تم حذف الكاتيجوري بنجاح"));
        }
    }
}
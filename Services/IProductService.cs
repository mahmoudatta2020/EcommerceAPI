using EcommerceAPI.DTOS;
using EcommerceAPI.Helpers;

namespace EcommerceAPI.Services
{
    public interface IProductService
    {
        Task<PagedList<ProductResponseDto>> GetAllAsync(PaginationParams paginationParams);
        Task<ProductResponseDto?> GetByIdAsync(int id);
        Task<ProductResponseDto> CreateAsync(CreateProductDto dto);
        Task<ProductResponseDto?> UpdateAsync(int id, CreateProductDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
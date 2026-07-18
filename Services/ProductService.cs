using EcommerceAPI.Data;
using EcommerceAPI.DTOS;
using EcommerceAPI.Exceptions;
using EcommerceAPI.Extensions;
using EcommerceAPI.Helpers;
using EcommerceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ProductResponseDto> CreateAsync(CreateProductDto dto)
        {
            if (dto.CategoryId.HasValue)
            {
                var category = await _context.Categories.FindAsync(dto.CategoryId.Value);
                if (category == null)
                    throw new NotFoundException($"الكاتيجوري رقم {dto.CategoryId} مش موجودة");
            }

            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Stock = dto.Stock,
                CategoryId = dto.CategoryId
            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product.ToDto();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                throw new NotFoundException($"المنتج رقم {id} مش موجود");

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<PagedList<ProductResponseDto>> GetAllAsync(PaginationParams paginationParams)
        {
            var query = _context.Products
                .Select(p => new ProductResponseDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Stock = p.Stock
                })
                .AsQueryable();

            return await PagedList<ProductResponseDto>.CreateAsync(
                query, paginationParams.PageNumber, paginationParams.PageSize);
        }

        public async Task<ProductResponseDto?> GetByIdAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                throw new NotFoundException($"المنتج رقم {id} مش موجود");
            return product.ToDto();
        }

        

        public async Task<ProductResponseDto?> UpdateAsync(int id, CreateProductDto dto)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                throw new NotFoundException($"المنتج رقم {id} مش موجود");

            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.Stock = dto.Stock;

            await _context.SaveChangesAsync();
            return product.ToDto();
        }
    }
}

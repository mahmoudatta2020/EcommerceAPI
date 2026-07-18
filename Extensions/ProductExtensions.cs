using EcommerceAPI.DTOS;
using EcommerceAPI.Models;

namespace EcommerceAPI.Extensions
{
    public static class ProductExtensions
    {
        public static ProductResponseDto ToDto(this Product product)
        {
            return new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock
            };
        }
    }
}
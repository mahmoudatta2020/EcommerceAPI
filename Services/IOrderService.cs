using EcommerceAPI.DTOs;
using EcommerceAPI.Models;

namespace EcommerceAPI.Services
{
    public interface IOrderService
    {
        Task<OrderResponseDto> CreateAsync(CreateOrderDto dto, string userId);
        Task<List<OrderResponseDto>> GetUserOrdersAsync(string userId);
        Task<OrderResponseDto?> GetByIdAsync(int id, string userId);
        Task<bool> CancelOrderAsync(int id, string userId);
        Task<OrderResponseDto> UpdateOrderStatusAsync(int id, OrderStatus status);
        Task<List<OrderResponseDto>> GetAllOrdersAsync();
    }
}
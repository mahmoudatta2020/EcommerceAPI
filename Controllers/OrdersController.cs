using EcommerceAPI.DTOs;
using EcommerceAPI.Helpers;
using EcommerceAPI.Models;
using EcommerceAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EcommerceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateOrderDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var order = await _orderService.CreateAsync(dto, userId!);
            return Ok(ApiResponse<OrderResponseDto>.SuccessResponse(order, "تمت إضافة الطلبية بنجاح"));
        }

        [HttpGet]
        public async Task<ActionResult> GetUserOrders()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orders = await _orderService.GetUserOrdersAsync(userId!);
            return Ok(ApiResponse<List<OrderResponseDto>>.SuccessResponse(orders, "تم جلب الطلبيات بنجاح"));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var order = await _orderService.GetByIdAsync(id, userId!);
            return Ok(ApiResponse<OrderResponseDto>.SuccessResponse(order, "تم جلب الطلبية بنجاح"));
        }

        [HttpPut("{id}/cancel")]
        public async Task<ActionResult> CancelOrder(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _orderService.CancelOrderAsync(id, userId!);
            return Ok(ApiResponse<string>.SuccessResponse(null, "تم إلغاء الطلبية بنجاح"));
        }

        [HttpPut("{id}/status")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateStatus(int id, [FromBody] OrderStatus status)
        {
            var order = await _orderService.UpdateOrderStatusAsync(id, status);
            return Ok(ApiResponse<OrderResponseDto>.SuccessResponse(order, "تم تعديل حالة الطلبية بنجاح"));
        }

        [HttpGet("all")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(ApiResponse<List<OrderResponseDto>>.SuccessResponse(orders, "تم جلب كل الطلبيات بنجاح"));
        }
    }
}
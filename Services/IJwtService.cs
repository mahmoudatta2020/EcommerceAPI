using EcommerceAPI.Models;

namespace EcommerceAPI.Services
{
    public interface IJwtService
    {
        Task<string> GenerateToken(AppUser user);
    }
}
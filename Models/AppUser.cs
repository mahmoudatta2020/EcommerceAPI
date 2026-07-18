using Microsoft.AspNetCore.Identity;

namespace EcommerceAPI.Models
{
    public class AppUser: IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}

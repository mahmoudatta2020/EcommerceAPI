using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.DTOS
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "الاسم مطلوب")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "الإيميل مطلوب")]
        [EmailAddress(ErrorMessage = "الإيميل مش صح")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "الباسورد مطلوب")]
        [MinLength(6, ErrorMessage = "الباسورد أقل حاجة 6 حروف")]
        public string Password { get; set; } = string.Empty;

        public string Role { get; set; } = "Customer";
    }
}

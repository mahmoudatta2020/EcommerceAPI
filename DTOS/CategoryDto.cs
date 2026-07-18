using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.DTOs
{
    public class CategoryDto
    {
        [Required(ErrorMessage = "اسم الكاتيجوري مطلوب")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "الاسم بين 3 و 100 حرف")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "الوصف أقل من 500 حرف")]
        public string Description { get; set; } = string.Empty;
    }
}
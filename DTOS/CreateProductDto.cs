using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.DTOS
{
    public class CreateProductDto
    {
        [Required(ErrorMessage = "اسم المنتج مطلوب")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "الاسم بين 3 و 100 حرف")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "الوصف أقل من 500 حرف")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "السعر مطلوب")]
        [Range(0.01, double.MaxValue, ErrorMessage = "السعر لازم يكون أكبر من 0")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "الكمية مطلوبة")]
        [Range(0, int.MaxValue, ErrorMessage = "الكمية لازم تكون 0 أو أكبر")]
        public int Stock { get; set; }
        public int? CategoryId { get; set; }

    }
}

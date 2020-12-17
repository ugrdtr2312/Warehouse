using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BLL.DTOs
{
    public class ProductDto : BaseDto
    {
        [Required, NotNull]
        public string ProductName { get; set; }
        [Required, NotNull]
        public int Amount { get; set; }
        [Required, NotNull]
        public decimal Price { get; set; }
        
        public int? BrandId { get; set; }
        public string BrandName { get; set; }
        
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        
        public int? SupplierId { get; set; }
        public string SupplierName { get; set; }
    }
}
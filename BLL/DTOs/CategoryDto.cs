using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BLL.DTOs
{
    public class CategoryDto : BaseDto
    {
        [Required, NotNull]
        public string CategoryName { get; set; }
        [Required, NotNull]
        public string Description { get; set; }
    }
}
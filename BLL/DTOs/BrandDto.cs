using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BLL.DTOs
{
    public class BrandDto : BaseDto
    {
        [Required, NotNull]
        public string BrandName { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BLL.DTOs
{
    public class SupplierDto : BaseDto
    {
        [Required, NotNull]
        public string CompanyName { get; set; }
        [Required, NotNull]
        public string FirstName { get; set; }
        [Required, NotNull]
        public string Surname { get; set; }
        [Required, NotNull]
        public string PhoneNumber { get; set; }
    }
}
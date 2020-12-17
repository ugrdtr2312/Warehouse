using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTOs;
using BLL.Interfaces;

namespace BLL.Services.Interfaces
{
    public interface IProductService : IService<ProductDto>
    {
        Task<IEnumerable<ProductDto>> GetAllBySupplierIdAsync(int supplierId);
        Task<IEnumerable<ProductDto>> GetAllByBrandIdAsync(int brandId);
        Task<IEnumerable<ProductDto>> GetAllByCategoryIdAsync(int categoryId);
    }
}
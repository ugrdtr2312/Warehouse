using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTOs;

namespace BLL.Interfaces
{
    public interface IService<TDto> where TDto : BaseDto
    {
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto> GetByIdAsync(int id);
        Task<TDto> CreateAsync(TDto dto);
        void Update(TDto dto);
        void Remove(int id);
    }
}
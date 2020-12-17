using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTOs;
using BLL.Exceptions;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services.Realizations
{
    public class CategoryService : ICategoryService
    {
        private readonly IUoW _uow;
        private readonly IMapper _mapper;

        public CategoryService(IUoW uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories =  await _uow.Categories.GetAllAsync();

            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var category =  await _uow.Categories.GetByIdAsync(id);
            
            if (category == null)
                throw new DbQueryResultNullException("Db query result to categories is null");

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<CategoryDto> CreateAsync(CategoryDto categoryDto)
        {
           var category = _mapper.Map<Category>(categoryDto);
            
            await _uow.Categories.CreateAsync(category);
            if (!await _uow.SaveChangesAsync())
                throw new DbQueryResultNullException("Changes to categories weren't produced");

            return _mapper.Map<CategoryDto>(category);
        }

        public void Update(CategoryDto categoryDto)
        {
            var category =  _uow.Categories.GetByIdAsync(categoryDto.Id).Result;
            
            if (category == null)
                throw new DbQueryResultNullException("There isn't such category in db");
            
            category = _mapper.Map<Category>(categoryDto);
            
            _uow.Categories.Update(category);
            if (!_uow.SaveChangesAsync().Result)
                throw new DbQueryResultNullException("Changes to categories weren't produced");
        }

        public void Remove(int id)
        {
            var category = _uow.Categories.GetByIdAsync(id).Result;
            
            if (category == null)
                throw new DbQueryResultNullException("No record to remove from categories");

            _uow.Categories.Remove(category);
            if (!_uow.SaveChangesAsync().Result)
                throw new DbQueryResultNullException("Changes to categories weren't produced");
        }
    }
}
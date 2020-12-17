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
    public class BrandService : IBrandService
    {
        private readonly IUoW _uow;
        private readonly IMapper _mapper;

        public BrandService(IUoW uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<BrandDto>> GetAllAsync()
        {
            var brands =  await _uow.Brands.GetAllAsync();

            return _mapper.Map<IEnumerable<BrandDto>>(brands);
        }

        public async Task<BrandDto> GetByIdAsync(int id)
        {
            var brand =  await _uow.Brands.GetByIdAsync(id);
            
            if (brand == null)
                throw new DbQueryResultNullException("Db query result to brands is null");

            return _mapper.Map<BrandDto>(brand);
        }

        public async Task<BrandDto> CreateAsync(BrandDto brandDto)
        { 
            var brand = _mapper.Map<Brand>(brandDto);
            
            await _uow.Brands.CreateAsync(brand);
            if (!await _uow.SaveChangesAsync())
                throw new DbQueryResultNullException("Changes to brands weren't produced");

            return _mapper.Map<BrandDto>(brand);
        }

        public void Update(BrandDto brandDto)
        {
            var brand =  _uow.Brands.GetByIdAsync(brandDto.Id).Result;
            
            if (brand == null)
                throw new DbQueryResultNullException("There isn't such brand in db");
            
            brand = _mapper.Map<Brand>(brandDto);
            
            _uow.Brands.Update(brand);
            if (!_uow.SaveChangesAsync().Result)
                throw new DbQueryResultNullException("Changes to brands weren't produced");
        }

        public void Remove(int id)
        {
            var brand = _uow.Brands.GetByIdAsync(id).Result;
            
            if (brand == null)
                throw new DbQueryResultNullException("No record to remove from brands");

            _uow.Brands.Remove(brand);
            if (!_uow.SaveChangesAsync().Result)
                throw new DbQueryResultNullException("Changes to brands weren't produced");
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTOs;
using BLL.Exceptions;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services.Realizations
{
    public class ProductService : IProductService
    {
        private readonly IUoW _uow;
        private readonly IMapper _mapper;

        public ProductService(IUoW uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products =  await _uow.Products.GetAllAsync();

            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var product =  await _uow.Products.GetByIdAsync(id);
            
            if (product == null)
                throw new DbQueryResultNullException("Db query result to products is null");

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> CreateAsync(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            
            await _uow.Products.CreateAsync(product);
            if (!await _uow.SaveChangesAsync())
                throw new DbQueryResultNullException("Changes to products weren't produced");

            return _mapper.Map<ProductDto>(product);
        }

        public void Update(ProductDto productDto)
        {
            var product =  _uow.Products.GetByIdAsync(productDto.Id).Result;
            
            if (product == null)
                throw new DbQueryResultNullException("There isn't such product in db");
            
            product = _mapper.Map<Product>(productDto);
            
            _uow.Products.Update(product);
            if (!_uow.SaveChangesAsync().Result)
                throw new DbQueryResultNullException("Changes to products weren't produced");
        }

        public void Remove(int id)
        {  
            var product = _uow.Products.GetByIdAsync(id).Result;
            
            if (product == null)
                throw new DbQueryResultNullException("No record to remove from products");

            _uow.Products.Remove(product);
            if (!_uow.SaveChangesAsync().Result)
                throw new DbQueryResultNullException("Changes to products weren't produced");
        }

        public async Task<IEnumerable<ProductDto>> GetAllBySupplierIdAsync(int supplierId)
        {
            var products =  await _uow.Products.GetAllAsync();

            var productsBySupplierId = products.Where(p => p.SupplierId == supplierId);
            
            return _mapper.Map<IEnumerable<ProductDto>>(productsBySupplierId);
        }

        public async Task<IEnumerable<ProductDto>> GetAllByBrandIdAsync(int brandId)
        {
            var products =  await _uow.Products.GetAllAsync();

            var productsByBrandId = products.Where(p => p.BrandId == brandId);
            
            return _mapper.Map<IEnumerable<ProductDto>>(productsByBrandId);
        }

        public async Task<IEnumerable<ProductDto>> GetAllByCategoryIdAsync(int categoryId)
        {
            var products =  await _uow.Products.GetAllAsync();

            var productsByCategoryId = products.Where(p => p.CategoryId == categoryId);
            
            return _mapper.Map<IEnumerable<ProductDto>>(productsByCategoryId);
        }
    }
}
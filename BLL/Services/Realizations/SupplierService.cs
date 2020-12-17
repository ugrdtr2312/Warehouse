﻿using System;
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
    public class SupplierService : ISupplierService
    {
        private readonly IUoW _uow;
        private readonly IMapper _mapper;

        public SupplierService(IUoW uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<SupplierDto>> GetAllAsync()
        {
            var suppliers =  await _uow.Suppliers.GetAllAsync();

            return _mapper.Map<IEnumerable<SupplierDto>>(suppliers);
        }

        public async Task<SupplierDto> GetByIdAsync(int id)
        {
            var supplier =  await _uow.Suppliers.GetByIdAsync(id);
            
            if (supplier == null)
                throw new DbQueryResultNullException("Db query result to suppliers is null");

            return _mapper.Map<SupplierDto>(supplier);
        }

        public async Task<SupplierDto> CreateAsync(SupplierDto supplierDto)
        {
            if (supplierDto == null)
                throw new DbQueryResultNullException("Db query result to suppliers is null");

            var supplier = _mapper.Map<Supplier>(supplierDto);
            
            await _uow.Suppliers.CreateAsync(supplier);
            if (!await _uow.SaveChangesAsync())
                throw new DbQueryResultNullException("Changes to suppliers weren't produced");

            return _mapper.Map<SupplierDto>(supplier);
        }

        public void Update(SupplierDto supplierDto)
        {
            /*if (supplierDto == null)
                throw new DbQueryResultNullException("Db query result to suppliers is null");

            var supplier = _mapper.Map<Supplier>(supplierDto);
            
            _uow.Suppliers.Update(supplier);
            await _uow.SaveChangesAsync();*/
        }

        public void Remove(int id)
        {
            /*var supplier = await _uow.Suppliers.GetByIdAsync(id);

            if (supplier == null)
                throw new DbQueryResultNullException("No record to remove from suppliers");

            _uow.Suppliers.Remove(supplier);
            if (!await _uow.SaveChangesAsync())
                throw new DbQueryResultNullException("Changes to suppliers weren't produced");*/
        }
    }
}
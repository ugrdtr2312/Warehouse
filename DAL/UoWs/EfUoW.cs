using System;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.UoWs
{
    public sealed class EfUoW : IUoW
    {
        private readonly DbContext _context;

        public EfUoW(DbContext context, IBrandRepository brandRepository, ICategoryRepository categoryRepository,
            IProductRepository productRepository, ISupplierRepository supplierRepository)
        {
            _context = context;
            Brands = brandRepository;
            Categories = categoryRepository;
            Products = productRepository;
            Suppliers = supplierRepository;
        }
       
        public IBrandRepository Brands { get; }
        public ICategoryRepository Categories { get; }
        public IProductRepository Products { get; }
        public ISupplierRepository Suppliers { get; }
       
        private bool _disposed;

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
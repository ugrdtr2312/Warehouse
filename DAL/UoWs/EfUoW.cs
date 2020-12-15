using System;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.UoWs
{
    public class EfUoW : IUoW
    {
        private readonly DbContext _context;

        public EfUoW(DbContext context, IBrandRepository brandRepository, ICategoryRepository categoryRepository,
            IProductRepository productRepository, ISupplierRepository supplierRepository)
        {
            _context = context;
            BrandRepository = brandRepository;
            CategoryRepository = categoryRepository;
            ProductRepository = productRepository;
            SupplierRepository = supplierRepository;
        }
       
        public IBrandRepository BrandRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public IProductRepository ProductRepository { get; }
        public ISupplierRepository SupplierRepository { get; }
       
        private bool _disposed;
        protected virtual void Dispose(bool disposing)
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
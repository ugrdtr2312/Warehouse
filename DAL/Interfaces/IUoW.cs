using System;
using System.Threading.Tasks;
using DAL.Repositories.Interfaces;

namespace DAL.Interfaces
{
    public interface IUoW : IDisposable
    {
        IBrandRepository BrandRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        ISupplierRepository SupplierRepository { get; }

        Task<bool> SaveChangesAsync();
    }
}
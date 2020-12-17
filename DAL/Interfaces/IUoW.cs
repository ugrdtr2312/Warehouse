using System;
using System.Threading.Tasks;
using DAL.Repositories.Interfaces;

namespace DAL.Interfaces
{
    public interface IUoW : IDisposable
    {
        IBrandRepository Brands { get; }
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }
        ISupplierRepository Suppliers { get; }

        Task<bool> SaveChangesAsync();
    }
}
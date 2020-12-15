using System.Linq;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.RealizationsWithIncludes
{
    public class ProductRepository : GenericRepositoryWithIncludes<Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        {
        }

        protected override IQueryable<Product> DbSetWithAllProperties()
        {
            return DbSet
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.Supplier);
        }
    }
}
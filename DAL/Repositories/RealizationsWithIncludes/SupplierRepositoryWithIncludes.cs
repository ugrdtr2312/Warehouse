using System.Linq;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.RealizationsWithIncludes
{
    public class SupplierRepositoryWithIncludes : GenericRepositoryWithIncludes<Supplier>, ISupplierRepository
    {
        public SupplierRepositoryWithIncludes(DbContext context) : base(context)
        {
        }

        protected override IQueryable<Supplier> DbSetWithAllProperties()
        {
            return DbSet.Include(s => s.Products);
        }
    }
}
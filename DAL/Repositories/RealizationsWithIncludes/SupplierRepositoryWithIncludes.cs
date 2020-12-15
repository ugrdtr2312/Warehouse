using System.Linq;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.RealizationsWithIncludes
{
    public class SupplierRepository : GenericRepositoryWithIncludes<Supplier>, ISupplierRepository
    {
        public SupplierRepository(DbContext context) : base(context)
        {
        }

        protected override IQueryable<Supplier> DbSetWithAllProperties()
        {
            return DbSet.Include(s => s.Products);
        }
    }
}
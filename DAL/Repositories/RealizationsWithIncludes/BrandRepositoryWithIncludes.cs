using System.Linq;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.RealizationsWithIncludes
{
    public class BrandRepositoryWithIncludes : GenericRepositoryWithIncludes<Brand>, IBrandRepository
    {
        public BrandRepositoryWithIncludes(DbContext context) : base(context)
        {
        }

        protected override IQueryable<Brand> DbSetWithAllProperties()
        {
            return DbSet.Include(b => b.Products);
        }
    }
}
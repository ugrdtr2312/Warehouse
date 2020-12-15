using System.Linq;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Realizations
{
    public class BrandRepository: GenericRepositoryWithIncludes<Brand>, IBrandRepository
    {
        public BrandRepository(DbContext context) : base(context)
        {
        }

        protected override IQueryable<Brand> DbSetWithAllProperties()
        {
            return DbSet;
        }
    }
}
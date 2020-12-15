using System.Linq;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.RealizationsWithIncludes
{
    public class CategoryRepository : GenericRepositoryWithIncludes<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context)
        {
        }

        protected override IQueryable<Category> DbSetWithAllProperties()
        {
            return DbSet.Include(c => c.Products);
        }
    }
}
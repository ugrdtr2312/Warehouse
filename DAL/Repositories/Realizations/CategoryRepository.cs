using System.Linq;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Realizations
{
    public class CategoryRepository : GenericRepositoryWithIncludes<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context)
        {
        }

        protected override IQueryable<Category> DbSetWithAllProperties()
        {
            return DbSet;
        }
    }
}
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .Property(c => c.CategoryName)
                .HasMaxLength(50)
                .IsRequired();
            
            builder
                .Property(c => c.Description)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
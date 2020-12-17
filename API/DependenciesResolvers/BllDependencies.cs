using BLL.Services.Interfaces;
using BLL.Services.Realizations;
using Microsoft.Extensions.DependencyInjection;

namespace API.DependenciesResolvers
{
    public static class BllDependencies
    {
        public static void BllDependenciesResolver(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISupplierService, SupplierService>();
        }
    }
}
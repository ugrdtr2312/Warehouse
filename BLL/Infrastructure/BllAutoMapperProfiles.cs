using AutoMapper;
using BLL.DTOs;
using DAL.Entities;

namespace BLL.Infrastructure
{
    public class BllAutoMapperProfiles : Profile
    {
        public BllAutoMapperProfiles()
        {
            CreateMap<Brand, BrandDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.BrandName, 
                    opt => opt.MapFrom(source => source.Brand.BrandName))
                .ForMember(dest => dest.SupplierName, 
                    opt => opt.MapFrom(source => source.Supplier.CompanyName))
                .ForMember(dest => dest.CategoryName, 
                    opt => opt.MapFrom(source => source.Category.CategoryName));
            CreateMap<ProductDto, Product>();
            CreateMap<Supplier, SupplierDto>().ReverseMap();
        }
    }
}
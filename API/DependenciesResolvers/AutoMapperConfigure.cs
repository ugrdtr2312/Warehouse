using AutoMapper;
using BLL.Infrastructure;

namespace API.DependenciesResolvers
{
    public static class AutoMapperConfigure
    {
        public static IMapper CreateMapper()
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new BllAutoMapperProfiles());
            });

            return mapperConfig.CreateMapper();
        }
    }
}
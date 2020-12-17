using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API.Infrastructure
{
    public static class SwaggerConfiguration
    {
        public static void SwaggerConfigure(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "WarehouseAPI",
                    Description = "Api provides work with the warehouse.",
                    Contact = new OpenApiContact
                    {
                        Name = "Shengeliya Vladimir",
                        Email = "vladimir231200@gmail.com",
                        Url = new Uri("https://github.com/ugrdtr2312"),
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
    }
}
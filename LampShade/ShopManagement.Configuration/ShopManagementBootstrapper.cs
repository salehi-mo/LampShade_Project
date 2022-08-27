using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Infrastructure.EfCore.Repository;
using System;
using _01_LampshadeQuery.Contracts.Product;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EfCore;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Infrastructure.EFCore.Repository;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.SlideAgg;
using _01_LampShadeQuery.Query;
using _01_LampShadeQuery.Contracts.Slide;
using _01_LampShadeQuery.Contracts.ProductCategory;
using _01_LampshadeQuery.Query;

namespace ShopManagement.Configuration
{
    public class ShopManagementBootstrapper
    {
        public static void Configure(IServiceCollection services,string connectionstring)
        {
            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();

            services.AddTransient<IProductApplication, ProductApplication>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddTransient<IProductPictureApplication, ProductPictureApplication>();
            services.AddTransient<IProductPictureRepository, ProductPictureRepository>();

            services.AddTransient<ISlideApplication, SlideApplication>();
            services.AddTransient<ISlideRepository, SlideRepository>();

            services.AddTransient<ISlideQuery, SlideQuery>();
            services.AddTransient<IProductCategoryQuery, ProductCategoryQuery>();



            services.AddTransient<ISlideQuery, SlideQuery>();
            services.AddTransient<IProductCategoryQuery, ProductCategoryQuery>();
            services.AddTransient<IProductQuery, ProductQuery>();
         


            //services.AddDbContext<ShopContext>(x => x.UseSqlServer(connectionstring, b => b.MigrationsAssembly("ServiceHost")));
            //services.AddDbContext<ShopContext>(x => x.UseSqlServer(connectionstring, b => b.MigrationsAssembly("ShopManagement.Infrastructure.EfCore")));
            services.AddDbContext<ShopContext>(x => x.UseSqlServer(connectionstring, b => b.MigrationsAssembly("ShopManagement.Infrastructure.EfCore")));

        }
    }
}

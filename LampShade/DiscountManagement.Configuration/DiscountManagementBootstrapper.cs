using DiscountManagement.Application;
using DiscountManagement.Application.Contracts.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManagement.Infrastructure.EfCore;
using DiscountManagement.Infrastructure.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Infrastructure;
using DiscountManagement.Application.Contracts.ColleagueDiscount;
using DiscountManagement.Configuration.Permissions;
using DiscountManagement.Domain.ColleagueDiscountAgg;

namespace DiscountManagement.Configuration
{
   public class DiscountManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<ICustomerDiscountApplication, CustomerDiscountApplication>();
            services.AddTransient<ICustomerDiscountRepository, CustomerDiscountRepository>();

            services.AddTransient<IColleagueDiscountApplication, ColleagueDiscountApplication>();
            services.AddTransient<IColleagueDiscountRepository, ColleagueDiscountRepository>();
            services.AddTransient<IPermissionExposer, DiscountPermissionExposer>();

            services.AddDbContext<DiscountContext>(x => x.UseSqlServer(connectionString, b => b.MigrationsAssembly("DiscountManagement.Infrastructure.EfCore")));
        }

    }
}

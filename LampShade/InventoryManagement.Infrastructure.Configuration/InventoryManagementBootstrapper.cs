using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Infrastructure;
using InventoryManagement.Application;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Infrastructure.Configuration.Permissions;
using InventoryManagement.Infrastructure.EFCore;
using InventoryMangement.Infrastructure.EFCore;
using InventoryManagement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using _01_LampshadeQuery.Contracts.Inventory;
using _01_LampshadeQuery.Query;

namespace InventoryManagement.Infrastructure.Configuration
{
    public class InventoryManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IInventoryRepository, InventoryRepository>();
            services.AddTransient<IInventoryApplication, InventoryApplication>();

            services.AddTransient<IPermissionExposer, InventoryPermissionExposer>();

            services.AddTransient<IInventoryQuery, InventoryQuery>();

            services.AddDbContext<InventoryContext>(x => x.UseSqlServer(connectionString, b => b.MigrationsAssembly("InventoryManagement.Infrastructure.EFCore"))); 
        }
    }
}

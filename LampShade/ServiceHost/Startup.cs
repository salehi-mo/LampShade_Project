
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopManagement.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;
using _0_Framework.Application;
using _0_Framework.Application.Email;
using _0_Framework.Application.Sms;
using _0_Framework.Application.ZarinPal;
using _0_Framework.Infrastructure;
using DiscountManagement.Configuration;
using InventoryManagement.Infrastructure.Configuration;
using BlogManagement.Infrastructure.Configuration;
using CommentManagement.Infrastructure.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using AccountManagement.Configuration;

using InventoryManagement.Presentation;
using ShopManagement.Presentation.Api;

namespace ServiceHost
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            var conectionstring = Configuration.GetConnectionString("LampshadeDb");
            ShopManagementBootstrapper.Configure(services, conectionstring);
            DiscountManagementBootstrapper.Configure(services, conectionstring);
            InventoryManagementBootstrapper.Configure(services, conectionstring);
            BlogManagementBootstrapper.Configure(services, conectionstring);
            CommentManagementBootstrapper.Configure(services, conectionstring);
            AccountManagementBootstrapper.Configure(services, conectionstring);

            services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic));
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddTransient<IFileUploader, FileUploader>();
            services.AddTransient<IAuthHelper, AuthHelper>();
            services.AddTransient<IZarinPalFactory, ZarinPalFactory>();
            services.AddTransient<ISmsService, SmsService>();
            services.AddTransient<IEmailService, EmailService>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                //options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.Lax;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
                {
                    o.LoginPath = new PathString("/Account");
                    o.LogoutPath = new PathString("/Account");
                    o.AccessDeniedPath = new PathString("/AccessDenied");
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminArea",
                    builder => builder.RequireRole(new List<string> {Roles.Administrator, Roles.ContentUploader}));

                options.AddPolicy("Shop",
                    builder => builder.RequireRole(new List<string> {Roles.Administrator, Roles.ContentUploader }));

                options.AddPolicy("Discount",
                    builder => builder.RequireRole(new List<string> {Roles.Administrator, Roles.ContentUploader }));

                options.AddPolicy("Account",
                    builder => builder.RequireRole(new List<string> {Roles.Administrator, Roles.ContentUploader }));
            });

            services.AddCors(options => options.AddPolicy("MyPolicy", builder =>
                builder
                    .WithOrigins("https://localhost:5002")
                    .AllowAnyHeader()
                    .AllowAnyMethod()));

            services.AddRazorPages()
                .AddMvcOptions(options => options.Filters.Add<SecurityPageFilter>())
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizeAreaFolder("Administration", "/", "AdminArea");
                    options.Conventions.AuthorizeAreaFolder("Administration", "/Shop", "Shop");
                    options.Conventions.AuthorizeAreaFolder("Administration", "/Discounts", "Discount");
                    options.Conventions.AuthorizeAreaFolder("Administration", "/Accounts", "Account");
                })
            .AddApplicationPart(typeof(ProductController).Assembly)
            .AddApplicationPart(typeof(InventoryController).Assembly)
            .AddNewtonsoftJson();

            ////services.AddMemoryCache();
            ////services.AddSession();
            ////services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseDeveloperExceptionPage();
                //app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("MyPolicy");

            //////app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });


        }
    }
}

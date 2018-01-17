using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AdProject.Domain.Entities;
using AdProject.Infrastructure.Identity;
using AdProject.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using AutoMapper;

namespace AdProject.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<IdentityContext>(options => options.UseSqlServer(Configuration.GetConnectionString("dbconexao")));
            services.AddDbContext<AdProjectContext>(option =>
                option.UseNpgsql(Configuration.GetConnectionString("dbconexaopg"),
                optionBuilder => optionBuilder.MigrationsAssembly("AdProject.Infrastructure")));

            services
                .AddIdentity<Infrastructure.Identity.AppUser, Infrastructure.Identity.AppRole>(option =>
                {
                    option.Lockout.AllowedForNewUsers = true;
                    option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                    option.Lockout.MaxFailedAccessAttempts = 5;

                    option.Password.RequireDigit = false;
                    option.Password.RequiredLength = 6;
                    option.Password.RequireLowercase = false;
                    option.Password.RequireNonAlphanumeric = false;
                    option.Password.RequireUppercase = false;

                    option.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<AdProjectContext>()
                .AddDefaultTokenProviders();

            services
                .ConfigureApplicationCookie(options =>
                {
                    options.LoginPath = "/Account/Login";
                });

            services.AddAutoMapper();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var supportedCultures = new[]
            {
                new CultureInfo("pt-br"),
                new CultureInfo("en-us"),
            };

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Site/Error");
            }

            app.UseRequestLocalization(new RequestLocalizationOptions()
            {
                DefaultRequestCulture = new RequestCulture("pt-br", "pt-br"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            app.UseAuthentication();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Site}/{action=Index}/{id?}");
            });
        }
    }
}

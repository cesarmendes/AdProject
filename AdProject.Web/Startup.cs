using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AdProject.Dominio.Entidades;
using AdProject.Infraestrutura.Identity;
using AdProject.Infraestrutura.BancoDados.Contextos;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using AutoMapper;
using AdProject.Web.Filters;

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
            //Configuração dos contextos de banco de dados
            ConfigureServicesContext(services);

            //Configuração do asp.net identity
            ConfigureServicesIdentity(services);

            #region Cookie auth configuration
            services
                .ConfigureApplicationCookie(options =>
                {
                    options.LoginPath = "/Conta/Entrar";
                    options.LogoutPath = "/Conta/Sair";
                    options.SlidingExpiration = true;
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                });
            #endregion

            #region AutoMapper configuration
            services.AddAutoMapper();
            #endregion

            services.AddMvc(config =>
            {
                config.Filters.Add<ExceptionsFilter>();
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler(new ExceptionHandlerOptions() { });
            }


            #region Use Globalization Culture
            var supportedCultures = new[]
            {
                new CultureInfo("pt-br"),
                new CultureInfo("en-us"),
            };

            app.UseRequestLocalization(new RequestLocalizationOptions()
            {
                DefaultRequestCulture = new RequestCulture("pt-br", "pt-br"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });
            #endregion

            app.UseAuthentication();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                     name: "areas",
                     template: "{area:exists}/{controller=Site}/{action=Index}/{id?}"
                   );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Site}/{action=Index}/{id?}");
            });
        }

        private void ConfigureServicesContext(IServiceCollection services)
        {
            services.AddDbContext<AdProjectContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("dbconexao"),
                    optionBuilder => optionBuilder.MigrationsAssembly("AdProject.Infraestrutura")));

            //services.AddDbContext<AdProjectContext>(option =>
            //    option.UseNpgsql(Configuration.GetConnectionString("dbconexaopg"),
            //    optionBuilder => optionBuilder.MigrationsAssembly("AdProject.Infraestrutura")));
        }

        private void ConfigureServicesIdentity(IServiceCollection services)
        {
            services
                .AddIdentity<AppUser, AppRole>(option =>
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
        }
    }
}

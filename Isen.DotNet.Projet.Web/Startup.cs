using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Isen.DotNet.Projet.Library.Data;
using Isen.DotNet.Projet.Library.Repository.InMemory;
using Isen.DotNet.Projet.Library.Repository.Interfaces;
using Isen.DotNet.Projet.Library.Repository.DbContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Isen.DotNet.Projet.Web
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
            // Utiliser Entity Framework
            services.AddDbContext<ApplicationDbContext>(options =>
                // Utiliser le provider Sqlite
                options.UseSqlite(
                    // Utiliser la clé DefaultConnection
                    // du fichier de config
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc();


            // Injection de dépendances
            /*services.AddScoped<IPIRepository, InMemoryPIRepository>();
            services.AddSingleton<IPIRepository, InMemoryPIRepository>();
            services.AddScoped<ICategorieRepository, InMemoryCategorieRepository>();
            services.AddSingleton<ICategorieRepository, InMemoryCategorieRepository>();
            services.AddScoped<IAdresseRepository, InMemoryAdresseRepository>();
            services.AddSingleton<IAdresseRepository, InMemoryAdresseRepository>();
            services.AddScoped<ICommuneRepository, InMemoryCommuneRepository>();
            services.AddSingleton<ICommuneRepository, InMemoryCommuneRepository>();*/

            // Injection des repo
            services.AddScoped<IPIRepository, DbContextPIRepository>();
            services.AddScoped<IAdresseRepository, DbContextAdresseRepository>();
            services.AddScoped<ICommuneRepository, DbContextCommuneRepository>();
            services.AddScoped<ICategorieRepository, DbContextCategorieRepository>();
            services.AddScoped<IDepartementRepository, DbContextDepartementRepository>();

            // injection d'autres services
            services.AddScoped<SeedData>();

            // AddTransient : nouvelle référence à chaque appel
            // AddSingleton : même référence pour toute l'appli, y compris
            //        entre différents appels http
            // AddScoped : même référence mais limitée à la durée de vie
            //     d'un appel http
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

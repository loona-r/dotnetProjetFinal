﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Isen.DotNet.Projet.Library.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Isen.DotNet.Projet.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            // Récupérer une instance de SeedData
            // en appelant le moteur d'injection de dépendances
            using (var scope = host.Services.CreateScope())
            {
                var seed = scope.ServiceProvider
                    .GetService<SeedData>();
                seed.DropDatabase();
                seed.CreateDatabase();
                seed.AddCategorie();
                seed.AddCommunes();
                seed.AddPI();
                seed.AddDepartement();
                seed.AddAdresse();
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}

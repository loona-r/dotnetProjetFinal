using System;
using Isen.DotNet.Projet.Library;
using Isen.DotNet.Projet.Library.Models.Implementation;
using Isen.DotNet.Projet.Library.Repository.InMemory;
using Isen.DotNet.Projet.Library.Repository.Interfaces;

namespace Isen.DotNet.Projet.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ICategorieRepository categorieRepository = new InMemoryCategorieRepository();
            ICommuneRepository communeRepository = new InMemoryCommuneRepository();
            IAdresseRepository adresseRepository = new InMemoryAdresseRepository(communeRepository);
            IPIRepository PIRepository = new InMemoryPIRepository(categorieRepository, adresseRepository);
            // Etat initial des villes
            foreach (var c in PIRepository.GetAll()) Console.WriteLine(c);
            Console.WriteLine("- - - - - - - -");
            // Ajouter une commune
            var toulon = new Commune { Nom = "Toulon" };
            communeRepository.Update(toulon);
            foreach (var c in communeRepository.GetAll()) Console.WriteLine(c);
            Console.WriteLine("- - - - - - - -");
        }
    }
}
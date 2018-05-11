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
            /*// Ajouter une ville
            var cannes = new City { Name = "Cannes" };
            cityRepository.Update(cannes);
            foreach(var c in cityRepository.GetAll()) Console.WriteLine(c);
            Console.WriteLine("- - - - - - - -");
            // Mettre à jour une ville
            var epinal = cityRepository.Single("Epinal");
            if (epinal != null)
            {
                epinal.Name += " sur mer";
                cityRepository.Update(epinal);
                foreach(var c in cityRepository.GetAll()) Console.WriteLine(c);
                Console.WriteLine("- - - - - - - -");
            }
            // ajout et mise à jour dans une même update
            var lyon = new City { Name = "Lyon" };
            if (epinal != null) epinal.Name = "Epinal";
            cityRepository.UpdateRange(lyon, epinal);
            foreach(var c in cityRepository.GetAll()) Console.WriteLine(c);
            Console.WriteLine("- - - - - - - -");

            // Ajout et mise à jour d'une personne
            var jonDoe = new Person
            {
                FirstName = "Jon",
                LastName = "DOE",
                BirthDate = new DateTime(1975,8,11),
                City = cityRepository.Single("Lyon")
            };
            var person2 = personRepository.Single(2);
            person2.BirthDate = 
                person2.BirthDate.Value.AddYears(-100);
            personRepository.UpdateRange(jonDoe, person2);
            foreach(var p in personRepository.GetAll()) Console.WriteLine(p);
            Console.WriteLine("- - - - - - - -");*/
        }
    }
}

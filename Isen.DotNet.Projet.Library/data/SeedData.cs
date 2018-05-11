using System;
using System.Collections.Generic;
using System.Linq;
using Isen.DotNet.Projet.Library.Models.Implementation;
using Isen.DotNet.Projet.Library.Repository.Interfaces;
using Microsoft.Extensions.Logging;

namespace Isen.DotNet.Projet.Library.Data
{
    public class SeedData
    {
        private readonly ApplicationDbContext _context;
        private readonly IPIRepository _PIRepository;
        private readonly IAdresseRepository _adresseRepository;
        private readonly ICategorieRepository _categorieRepository;
        private readonly ICommuneRepository _communeRepository;
        private readonly IDepartementRepository _departementRepository;

        public SeedData(
            ApplicationDbContext context,
            IPIRepository PIRepository,
            IAdresseRepository adresseRepository,
            ICategorieRepository categorieRepository,
            ICommuneRepository communeRepository,
            IDepartementRepository departementRepository)
        {
            _context = context;
            _PIRepository = PIRepository;
            _adresseRepository = adresseRepository;
            _communeRepository = communeRepository;
            _categorieRepository = categorieRepository;
            _departementRepository = departementRepository;
        }

        public void DropDatabase()
        {
            var deleted = _context.Database.EnsureDeleted();
            var not = deleted ? "" : "not ";
        }

        public void CreateDatabase()
        {
            var created = _context.Database.EnsureCreated();
            var not = created ? "" : "not ";
        }

        public void AddCommunes()
        {
            if (_communeRepository.GetAll().Any()) return; ;

            var communes = new List<Commune>
            {
                new Commune
                {
                    Nom = "Toulon",
                    Lattitude = 43.116667,
                    Longitude = 5.933333
                },
                new Commune
                {
                    Nom = "Le Pradet",
                    Lattitude = 43.0983906,
                    Longitude = 6.0038674
                },
            };
            _communeRepository.UpdateRange(communes);
            _communeRepository.Save();
        }

        public void AddCategorie()
        {
            if (_categorieRepository.GetAll().Any()) return;

            var categories = new List<Categorie>
            {
                new Categorie
                {
                    Nom = "Domicile",
                    Descriptif = "Là où on habite"
                },
                new Categorie
                {
                    Nom = "Divertissement",
                    Descriptif = "Là où on s'amuse"
                }
            };
            _categorieRepository.UpdateRange(categories);
            _categorieRepository.Save();
        }

        public void AddDepartement()
        {
            if (_departementRepository.GetAll().Any()) return;

            var departements = new List<Departement>
            {
                new Departement
                {
                    Nom = "Var",
                    Numero = 83
                },
                new Departement
                {
                    Nom = "Vaucluse",
                    Numero = 84
                }
            };
            _departementRepository.UpdateRange(departements);
            _departementRepository.Save();
        }

        public void AddAdresse()
        {
            if (_adresseRepository.GetAll().Any()) return;

            var addresses = new List<Adresse>
            {
                new Adresse
                {
                    Texte = "468 chemin de la Foux",
                    CodePostal = 83220,
                    Commune = _communeRepository.Single(1),
                    Lattitude = 43.1124007,
                    Longitude = 6.0298874
                },
                new Adresse
                {
                    Texte = "Rue Henri Pertus",
                    CodePostal = 83000,
                    Commune = _communeRepository.Single(1),
                    Lattitude = 43.120045,
                    Longitude = 5.935859
                }
            };
            _adresseRepository.UpdateRange(addresses);
            _adresseRepository.Save();
        }

        public void AddPI()
        {
            if (_PIRepository.GetAll().Any()) return;

            var PIs = new List<PI>
            {
                new PI
                {
                    Nom = "Maison de Loona",
                    Descriptif = "Là où Loona habite",
                    Categorie = _categorieRepository.Single(1),
                    Adresse = _adresseRepository.Single(1),
                },
                new PI
                {
                    Nom = "Maison de Lisa",
                    Descriptif = "Là où Lisa habite",
                    Categorie = _categorieRepository.Single(1),
                    Adresse = _adresseRepository.Single(1),
                }
            };
            _PIRepository.UpdateRange(PIs);
            _PIRepository.Save();
        }
    }
}
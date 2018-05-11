using System.Collections.Generic;
using System.Linq;
using Isen.DotNet.Projet.Library.Models.Implementation;
using Isen.DotNet.Projet.Library.Repository.Base;
using Isen.DotNet.Projet.Library.Repository.Interfaces;
using Microsoft.Extensions.Logging;

namespace Isen.DotNet.Projet.Library.Repository.InMemory
{
    public class InMemoryPIRepository : BaseInMemoryRepository<PI>, IPIRepository
    {
        private ICategorieRepository _categorieRepository;
        private IAdresseRepository _adresseRepository;

        public InMemoryPIRepository(ICategorieRepository categorieRepository, IAdresseRepository adresseRepository)
        {
            _categorieRepository = categorieRepository;
            _adresseRepository = adresseRepository;
        }

        public override IQueryable<PI> ModelCollection
        {
            get
            {
                if (_modelCollection == null)
                {
                    _modelCollection = new List<PI>
                    {
                        new PI
                        {
                            Id = 1,
                            Nom = "Maison de Loona",
                            Descriptif = "Là où Loona habite",
                            Categorie = _categorieRepository.Single(1),
                            Adresse = _adresseRepository.Single(1),
                        },
                    };
                }
                return _modelCollection.AsQueryable();
            }
        }

    }
}
using System.Collections.Generic;
using System.Linq;
using Isen.DotNet.Projet.Library.Models.Implementation;
using Isen.DotNet.Projet.Library.Repository.Base;
using Isen.DotNet.Projet.Library.Repository.Interfaces;
using Microsoft.Extensions.Logging;

namespace Isen.DotNet.Projet.Library.Repository.InMemory
{
    public class InMemoryAdresseRepository : BaseInMemoryRepository<Adresse>, IAdresseRepository
    {
        private ICommuneRepository _communeRepository;
        public InMemoryAdresseRepository(ICommuneRepository communeRepository)
        {
            _communeRepository = communeRepository;
        }

        public override IQueryable<Adresse> ModelCollection
        {
            get
            {
                if (_modelCollection == null)
                {
                    _modelCollection = new List<Adresse>
                    {
                        new Adresse
                        {
                            Id = 1,
                            Nom = "468 chemin de la Foux",
                            CodePostal = 83220,
                            Commune = _communeRepository.Single(1),
                            Lattitude = 43.1124007,
                            Longitude = 6.0298874
                        },
                    };
                }
                return _modelCollection.AsQueryable();
            }
        }
    }
}
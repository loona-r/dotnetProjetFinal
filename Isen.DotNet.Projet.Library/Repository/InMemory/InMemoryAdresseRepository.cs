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
        public InMemoryAdresseRepository(
            ILogger<InMemoryAdresseRepository> logger) : base(logger)
        {
        }

        public override IQueryable<Adresse> ModelCollection
        {
            get
            {
                if (_modelCollection == null)
                {
                    _modelCollection = new List<Adresse>
                    {
                        new Adresse { Id = 1, CodePostal = 83000 },
                    };
                }
                return _modelCollection.AsQueryable();
            }
        }


    }
}
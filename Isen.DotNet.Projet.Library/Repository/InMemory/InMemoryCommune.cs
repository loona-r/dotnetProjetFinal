using System.Collections.Generic;
using System.Linq;
using Isen.DotNet.Projet.Library.Models.Implementation;
using Isen.DotNet.Projet.Library.Repository.Base;
using Isen.DotNet.Projet.Library.Repository.Interfaces;
using Microsoft.Extensions.Logging;

namespace Isen.DotNet.Projet.Library.Repository.InMemory
{
    public class InMemoryCommuneRepository : BaseInMemoryRepository<Commune>, ICommuneRepository
    {
        public InMemoryCommuneRepository(
            ILogger<InMemoryCommuneRepository> logger) : base(logger)
        {
        }

        public override IQueryable<Commune> ModelCollection
        {
            get
            {
                if (_modelCollection == null)
                {
                    _modelCollection = new List<Commune>
                    {
                        new Commune { Id = 1 },
                };
                }
                return _modelCollection.AsQueryable();
            }
        }


    }
}
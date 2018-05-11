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
        public InMemoryPIRepository(
            ILogger<InMemoryPIRepository> logger) : base(logger)
        {
        }

        public override IQueryable<PI> ModelCollection
        {
            get
            {
                if (_modelCollection == null)
                {
                    _modelCollection = new List<PI>
                    {
                        new PI { Id = 1 },
                    };
                }
                return _modelCollection.AsQueryable();
            }
        }


    }
}
using System.Collections.Generic;
using System.Linq;
using Isen.DotNet.Projet.Library.Models.Implementation;
using Isen.DotNet.Projet.Library.Repository.Base;
using Isen.DotNet.Projet.Library.Repository.Interfaces;
using Microsoft.Extensions.Logging;

namespace Isen.DotNet.Projet.Library.Repository.InMemory
{
    public class InMemoryDepartementRepository : BaseInMemoryRepository<Departement>, IDepartementRepository
    {
        public InMemoryDepartementRepository() { }
        public InMemoryDepartementRepository(
            ILogger<InMemoryDepartementRepository> logger) : base(logger)
        {
        }

        public override IQueryable<Departement> ModelCollection
        {
            get
            {
                if (_modelCollection == null)
                {
                    _modelCollection = new List<Departement>
                    {
                        new Departement
                        {
                            Id = 1,
                            Nom = "Var",
                            Numero = 83,
                        },
                    };
                }
                return _modelCollection.AsQueryable();
            }
        }



        /*public virtual Departement Single(int num)
        {
            var queryable = ModelCollection;
            queryable = Includes(queryable);
            return queryable.SingleOrDefault(c => c.Numero == num);
        }*/

    }
}
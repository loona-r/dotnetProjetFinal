using System.Collections.Generic;
using System.Linq;
using Isen.DotNet.Projet.Library.Models.Implementation;
using Isen.DotNet.Projet.Library.Repository.Base;
using Isen.DotNet.Projet.Library.Repository.Interfaces;
using Microsoft.Extensions.Logging;

namespace Isen.DotNet.Projet.Library.Repository.InMemory
{
    public class InMemoryCategorieRepository : BaseInMemoryRepository<Categorie>, ICategorieRepository
    {
        public InMemoryCategorieRepository() { }
        public InMemoryCategorieRepository(
            ILogger<InMemoryCategorieRepository> logger) : base(logger)
        {
        }

        public override IQueryable<Categorie> ModelCollection
        {
            get
            {
                if (_modelCollection == null)
                {
                    _modelCollection = new List<Categorie>
                    {
                        new Categorie
                        {
                            Id = 1,
                            Nom = "Domicile",
                            Descriptif = "Là où on habite",
                        },
                };
                }
                return _modelCollection.AsQueryable();
            }
        }


    }
}
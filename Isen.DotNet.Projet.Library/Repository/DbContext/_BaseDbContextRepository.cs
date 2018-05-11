using System.Collections.Generic;
using System.Linq;
using Isen.DotNet.Projet.Library.Data;
using Isen.DotNet.Projet.Library.Models.Base;
using Isen.DotNet.Projet.Library.Models.Implementation;
using Isen.DotNet.Projet.Library.Repository.Base;
using Isen.DotNet.Projet.Library.Repository.Interfaces;
using Microsoft.Extensions.Logging;

namespace Isen.DotNet.Projet.Library.Repository.DbContext
{
    public abstract class BaseDbContextRepository<T> :
        BaseRepository<T>
            where T : BaseModel
    {
        // Référence au contexte EntityFramework (injecté)
        protected readonly ApplicationDbContext Context;

        // Implémentation concrète de la liste de T
        public override IQueryable<T> ModelCollection
            => Context.Set<T>().AsQueryable();

        public BaseDbContextRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public override void Delete(int id)
        {
            var model = Single(id);
            if (model != null) Context.Remove(model);
        }

        public override void Update(T model)
        {
            if (model.IsNew) Context.Add(model);
            else Context.Update(model);
        }

        public override void Save()
        {
            Context.SaveChanges();
        }
    }
}
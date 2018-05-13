using System.Collections.Generic;
using System.Linq;
using Isen.DotNet.Projet.Library.Data;
using Isen.DotNet.Projet.Library.Models.Base;
using Isen.DotNet.Projet.Library.Models.Implementation;
using Isen.DotNet.Projet.Library.Repository.Base;
using Isen.DotNet.Projet.Library.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Isen.DotNet.Projet.Library.Repository.DbContext
{
    public class DbContextCommuneRepository :
        BaseDbContextRepository<Commune>, ICommuneRepository
    {
        public DbContextCommuneRepository(
            ApplicationDbContext context) : base(context)
        {
        }
        public override IQueryable<Commune> Includes(
            IQueryable<Commune> queryable)
                => queryable.Include(c => c.AdresseCollection);
    }
}
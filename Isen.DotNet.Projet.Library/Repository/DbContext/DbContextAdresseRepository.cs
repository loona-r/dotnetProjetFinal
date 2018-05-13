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
    public class DbContextAdresseRepository :
        BaseDbContextRepository<Adresse>, IAdresseRepository
    {
        public DbContextAdresseRepository(
            ApplicationDbContext context) : base(context)
        {
        }
        public override IQueryable<Adresse> Includes(
            IQueryable<Adresse> queryable)
                => queryable.Include(a => a.PICollection);
    }
}
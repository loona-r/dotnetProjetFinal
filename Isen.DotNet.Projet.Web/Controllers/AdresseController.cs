using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Isen.DotNet.Projet.Web.Models;
using Isen.DotNet.Projet.Library.Repository.Interfaces;
using Isen.DotNet.Projet.Library.Repository.InMemory;
using Isen.DotNet.Projet.Library.Models.Implementation;
using Microsoft.Extensions.Logging;

namespace Isen.DotNet.Projet.Web.Controllers
{
    public class AdresseController : BaseController<Adresse>
    {
        public AdresseController(IAdresseRepository repository) : base(repository)
        {
        }
    }
}
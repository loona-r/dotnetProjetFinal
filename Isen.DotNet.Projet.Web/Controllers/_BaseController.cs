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
using Isen.DotNet.Projet.Library.Models.Base;

namespace Isen.DotNet.Projet.Web.Controllers
{
    public abstract partial class BaseController<T> : Controller
        where T : BaseModel
    {
        protected IBaseRepository<T> _repository;
        protected readonly ILogger<BaseController<T>> _logger;

        public BaseController(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual IActionResult Index()
        {            
            var model = _repository.GetAll();
            return View(model);
        }

        public virtual IActionResult Detail(int? id)
        {
            // Pas d'id > form vide (création)
            if (id == null) return View();
            // Récupérer la ville et la passer à la vue
            var model = _repository.Single(id.Value);
            return View(model);
        }

        [HttpPost]
        public virtual IActionResult Detail(T model)
        {
            _repository.Update(model);
            _repository.Save();
            return RedirectToAction("Index");
        }

        public virtual IActionResult Delete(int? id)
        {
            if (id != null)
            {
                _repository.Delete(id.Value);
                _repository.Save();
            }
            return RedirectToAction("Index");
        }
    }
}
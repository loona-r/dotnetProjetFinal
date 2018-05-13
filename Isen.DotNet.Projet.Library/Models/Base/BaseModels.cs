using System;
using System.Dynamic;

namespace Isen.DotNet.Projet.Library.Models.Base
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public virtual string Nom { get;set; }

        public virtual string Display =>
            $"[Id={Id}]";

        public override string ToString() => Display;

        public bool IsNew => Id <= 0;

        public virtual dynamic ToDynamic()
        {
            dynamic response = new ExpandoObject();
            response.id = Id;
            response.nom = Nom;
            response.fetch = DateTime.Now;

            return response;
        }
    }
}
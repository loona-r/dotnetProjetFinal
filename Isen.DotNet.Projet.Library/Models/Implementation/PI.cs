using System;
using Isen.DotNet.Projet.Library.Models.Base;

namespace Isen.DotNet.Projet.Library.Models.Implementation
{
    public class PI : BaseModel
    {
        public string Descriptif { get; set; }
        public Categorie Categorie { get; set; }
        public Adresse Adresse { get; set; }

        public int? AdresseID { get;set; }
        public int? CategorieID { get;set; }

        public override string Display =>
            $"{Nom} : {Adresse} | {Categorie}";

            public override dynamic ToDynamic()
        {
            var response = base.ToDynamic();
            response.desc = Descriptif;
            response.cat = Categorie?.ToDynamic();
            response.adresse = Adresse?.ToDynamic();
            return response;
        }
    }

}
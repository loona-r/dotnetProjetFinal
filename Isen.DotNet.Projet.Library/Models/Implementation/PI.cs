using System;
using Isen.DotNet.Projet.Library.Models.Base;

namespace Isen.DotNet.Projet.Library.Models.Implementation
{
    public class PI : BaseModel
    {
        public string Nom { get; set; }
        public string Descriptif { get; set; }
        public Categorie Categorie { get; set; }
        public Adresse Adresse { get; set; }

        public override string Display =>
            $"[[PI]]{base.Display}|Nom={Nom}|Descriptif={Descriptif}|Catégorie={Categorie}|Adresse={Adresse}";
    }

}
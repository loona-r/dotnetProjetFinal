using System;
using Isen.DotNet.Projet.Library.Models.Base;

namespace Isen.DotNet.Projet.Library.Models.Implementation
{
    public class Categorie : BaseModel
    {
        public string Descriptif { get; set; }

        public override string Display =>
            $"{Nom}";
    }

}
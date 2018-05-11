using System;
using Isen.DotNet.Projet.Library.Models.Base;

namespace Isen.DotNet.Projet.Library.Models.Implementation
{
    public class Categorie : BaseModel
    {
        public string Nom { get; set; }
        public string Descriptif { get; set; }
    }

}
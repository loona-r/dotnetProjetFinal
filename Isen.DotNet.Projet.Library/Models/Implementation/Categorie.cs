using System;
using System.Collections.Generic;
using Isen.DotNet.Projet.Library.Models.Base;

namespace Isen.DotNet.Projet.Library.Models.Implementation
{
    public class Categorie : BaseModel
    {
        public string Descriptif { get; set; }
        
        
        public List<PI> PICollection { get;set; }
        public int? PICount => PICollection?.Count;

        public override string Display =>
            $"{Nom}";

            
    }

}
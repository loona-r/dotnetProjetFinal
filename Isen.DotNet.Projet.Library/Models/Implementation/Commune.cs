using System;
using System.Collections.Generic;
using Isen.DotNet.Projet.Library.Models.Base;

namespace Isen.DotNet.Projet.Library.Models.Implementation
{
    public class Commune : BaseModel
    {
        public double Lattitude { get; set; }
        public double Longitude { get; set; }

         public List<Adresse> AdresseCollection { get;set; }
        public int? AdresseCount => AdresseCollection?.Count;

        public override dynamic ToDynamic()
        {
            var response = base.ToDynamic();
            response.nb = AdresseCount;
            return response;
        }

        public override string Display =>
            $"{Nom}";
    }

}
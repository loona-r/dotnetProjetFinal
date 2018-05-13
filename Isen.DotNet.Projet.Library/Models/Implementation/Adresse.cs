using System;
using System.Collections.Generic;
using Isen.DotNet.Projet.Library.Models.Base;

namespace Isen.DotNet.Projet.Library.Models.Implementation
{
    public class Adresse : BaseModel
    {
        public long CodePostal { get; set; }
        public Commune Commune { get; set; }
        public double Lattitude { get; set; }
        public double Longitude { get; set; }
        public int? CommuneID { get;set; }
        public List<PI> PICollection { get;set; }
        public int? PICount => PICollection?.Count;


        public override string Display =>
            $"{Nom}, {CodePostal} {Commune}";
    }

}
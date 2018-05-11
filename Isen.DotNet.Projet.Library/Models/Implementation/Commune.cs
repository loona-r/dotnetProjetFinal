using System;
using Isen.DotNet.Projet.Library.Models.Base;

namespace Isen.DotNet.Projet.Library.Models.Implementation
{
    public class Commune : BaseModel
    {
        public string Nom { get; set; }
        public double Lattitude { get; set; }
        public double Longitude { get; set; }

        public override string Display =>
            $"[[Commune]]{base.Display}|Nom={Nom}|Lattitude={Lattitude}|Longitude={Longitude}";
    }

}
using System;
using Isen.DotNet.Projet.Library.Models.Base;

namespace Isen.DotNet.Projet.Library.Models.Implementation
{
    public class Adresse : BaseModel
    {
        public string Texte { get; set; }
        public long CodePostal { get; set; }
        public Commune Commune { get; set; }
        public double Lattitude { get; set; }
        public double Longitude { get; set; }
    }

}
using System;

namespace Isen.DotNet.Projet.Library.Models.Implementation
{
    public class Adresse
    {
        public string Texte { get; set; }
        public long CodePostal { get; set; }
        public Commune Commune { get; set; }
        public float Lattitude { get; set; }
        public float Longitude { get; set; }
    }

}
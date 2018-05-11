using System;
using Isen.DotNet.Projet.Library.Models.Base;

namespace Isen.DotNet.Projet.Library.Models.Implementation
{
    public class Commune : BaseModel
    {
        public string Nom { get; set; }
        public float Lattitude { get; set; }
        public float Longitude { get; set; }
    }

}
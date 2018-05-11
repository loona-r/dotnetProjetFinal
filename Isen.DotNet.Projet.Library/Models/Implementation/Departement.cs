using System;
using Isen.DotNet.Projet.Library.Models.Base;

namespace Isen.DotNet.Projet.Library.Models.Implementation
{
    public class Departement : BaseModel
    {
        public string Nom { get; set; }
        public int Numero { get; set; }

        public override string Display =>
            $"[[Departement]]{base.Display}|Nom={Nom}|Numero={Numero}";
    }

}
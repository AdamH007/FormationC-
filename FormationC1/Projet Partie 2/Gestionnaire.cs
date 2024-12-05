using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Partie_2
{
    class Gestionnaire
    {
        public uint IdentifiantGestionnaire { get; private set; }
        public string Type { get; private set; }
        public decimal FraisGestion { get; set; } 


        public Gestionnaire(uint identifiantGestionnaire, string type, decimal fraisGestion)
        {
            IdentifiantGestionnaire = identifiantGestionnaire;
            Type = type;
            FraisGestion = fraisGestion;
        }

    }
}

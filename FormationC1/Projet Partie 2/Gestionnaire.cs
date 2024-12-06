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
        public int NombreTransMaxRetrait { get; set; }
        private Dictionary<uint, Compte> _comptes;


        public Gestionnaire(uint identifiantGestionnaire, string type, decimal fraisGestion, int nombreTransMaxRetrait)
        {
            IdentifiantGestionnaire = identifiantGestionnaire;
            Type = type;
            FraisGestion = fraisGestion;
            NombreTransMaxRetrait = nombreTransMaxRetrait;

        }

        public bool CreerCompte(Compte compte)
        {
            if (_comptes.ContainsKey(compte.IdentifiantCompte))
            {
                return false;
            }
            _comptes.Add(compte.IdentifiantCompte, compte);
            return true;
        }

        public bool VerifCompteExisteActif(uint identifiantCompte, DateTime dateTransaction)
        {
            return _comptes.ContainsKey(identifiantCompte) && dateTransaction < _comptes[identifiantCompte].DateResiliation && dateTransaction >= _comptes[identifiantCompte].DateCreation;
        }

        public bool CloturerCompte(uint identifiantCompte, DateTime dateCloture)
        {
            if (!VerifCompteExisteActif(identifiantCompte, dateCloture))
            {
                return false;
            }
            _comptes[identifiantCompte].DateResiliation = dateCloture;
            return true;
        }

    }
}

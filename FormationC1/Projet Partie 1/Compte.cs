using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Partie_1
{
    class Compte
    {
        public uint IdentifiantCompte { get; private set; }
        public decimal Solde { get; private set; }
        private const int _maxRetrait = 1000;
        private List<Decimal> _historique = new List<Decimal>();

        public decimal CumulDes10DernieresTrans(decimal montant)
        {
            decimal CumulDes10DernieresTrans = montant;

            foreach (Decimal elem in _historique)
            {
                CumulDes10DernieresTrans += elem;
            }
            return CumulDes10DernieresTrans;
        }

        public void AjoutHistorique(Decimal trans)
        {
            if (_historique.Count < 9)
            {
                _historique.Add(trans);
            }
            else
            {
                _historique.RemoveAt(0);
                _historique.Add(trans);
            }
        }

        public Compte(uint identifiantCompte, decimal solde = 0)
        {
            IdentifiantCompte = identifiantCompte;
            Solde = solde;
        }

        public bool VerifDepot(decimal montant)
        {
            if (montant <= 0)
            {
                return false;
            }
            Solde += montant;
            return true;
        }

        public bool VerifRetrait(decimal montant)
        {
            if (montant <= 0)
            {
                Console.WriteLine("Le montant est négatif!");
                return false;               
            }
            else if (montant > Solde)
            {
                Console.WriteLine("Solde insuffisant!");
                return false;
            }
            else if (CumulDes10DernieresTrans(montant) >= _maxRetrait)
            {
                Console.WriteLine("Montant maximum atteint!");
                return false;
            }
            Solde -= montant;
            return true;
        }

        public void Depot(decimal montant)
        {
            Solde += montant;
        }

        public void Retrait(decimal montant)
        {
            Solde -= montant;
            _historique.Add(montant);
        }
    }
}

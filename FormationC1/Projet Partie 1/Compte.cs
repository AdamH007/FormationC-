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

        public Compte(uint identifiantCompte, decimal solde = 0)
        {
            IdentifiantCompte = identifiantCompte;
            Solde = solde;
        }

        // Calcul du cumul des 10 dernières transactions
        public decimal CumulDes10DernieresTrans(decimal montant)
        {
            decimal CumulDes10DernieresTrans = montant;
            int limiteurDeCompteur = 0;

            if (_historique.Count < 9)
            {
                limiteurDeCompteur = _historique.Count;
            }
            else
            {
                limiteurDeCompteur = 9;
            }

            for (int i = _historique.Count - limiteurDeCompteur; i < _historique.Count; i++)
            {
                CumulDes10DernieresTrans += _historique[i];
            }

            return CumulDes10DernieresTrans;
        }

        public void AjoutHistorique(Decimal trans)
        {
            _historique.Add(trans);
        }

        public bool VerifDepot(decimal montant)
        {
            if (montant <= 0)
            {
                return false;
            }
            return true;
        }

        public bool VerifRetrait(decimal montant)
        {
            Console.WriteLine($"Identifiant: {IdentifiantCompte}, solde: {Solde}, montant: {montant}, somme: {CumulDes10DernieresTrans(montant)}");
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
                Console.WriteLine("Retrait maximum atteint!");
                return false;
            }
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

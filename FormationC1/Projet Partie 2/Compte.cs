using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Partie_2
{
    class Compte
    {
        public uint IdentifiantCompte { get; private set; }
        public decimal Solde { get; private set; }
        private const decimal _maxRetrait = 1000;
        public DateTime DateCreation { get; set; }
        public DateTime DateResiliation { get; set; }
        public int NombreTransMaxRetrait { get; set; }
        private const decimal _maxRetraitUneSemaine = 2000;
        private TimeSpan _semaineMaxRetrait = new TimeSpan(7, 0, 0, 0);
        private List<Decimal> _historique = new List<Decimal>();
        private List<KeyValuePair<decimal, DateTime>> _historiqueUneSemaine;

        public Compte(uint identifiantCompte, DateTime dateCreation, int nombreTransMaxRertrait, decimal solde = 0)
        {
            IdentifiantCompte = identifiantCompte;
            DateCreation = dateCreation;
            NombreTransMaxRetrait = nombreTransMaxRertrait;
            Solde = solde;
        }

        public void AjoutHistorique(decimal trans)
        {
            _historique.Add(trans);
        }

        public bool VerifDepot(Transaction transaction)
        {
            if (transaction.Montant <= 0 || transaction.DateEffet <= DateCreation || transaction.DateEffet >= DateResiliation )
            {
                return false;
            }
            return true;
        }

        public bool VerifRetrait(decimal montant)
        {
            //Console.WriteLine($"Identifiant: {IdentifiantCompte}, solde: {Solde}, montant: {montant}, somme: {CumulDes10DernieresTrans(montant)}");
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
            /*else if (CumulDes10DernieresTrans(montant) >= _maxRetrait)
            {
                Console.WriteLine("Retrait maximum atteint!");
                return false;
            }*/
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

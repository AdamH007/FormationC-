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

        public Compte(uint identifiantCompte, DateTime dateCreation, DateTime dateResiliation, int nombreTransMaxRertrait, decimal solde = 0)
        {
            IdentifiantCompte = identifiantCompte;
            DateCreation = dateCreation;
            DateResiliation = dateResiliation;
            NombreTransMaxRetrait = nombreTransMaxRertrait;
            Solde = solde;
        }

        private bool MaxRetrait(decimal montant)
        {
            decimal totalRetraits = montant;
            for (int i = 0; i < NombreTransMaxRetrait - 1 && i < _historique.Count(); i++)
            {
                totalRetraits += _historique[i];
            }
            if (totalRetraits > _maxRetrait)
            {
                return true;
            }
            return false;
        }

        private bool MaxRetraitUneSemaine(decimal montant, DateTime dateEffet)
        {
            decimal totalRetraits = montant;
            foreach (KeyValuePair<decimal, DateTime> retrait in _historiqueUneSemaine)
            {
                if (retrait.Value <= dateEffet && dateEffet - retrait.Value < _semaineMaxRetrait && retrait.Value >= DateCreation && retrait.Value < DateResiliation)
                {
                    totalRetraits += retrait.Key;
                }
            }
            if (totalRetraits > _maxRetraitUneSemaine)
            {
                return true;
            }
            return false;
        }
                  

        public void AjoutHistorique(decimal trans)
        {
            _historique.Add(trans);
        }

        public void AjoutHistoriqueUneSemaine(decimal trans, DateTime dateEffet)
        {
            _historiqueUneSemaine.Add(new KeyValuePair<decimal, DateTime>(trans, dateEffet));
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

            return true;
        }

        public void Depot(decimal montant)
        {
            Solde += montant;
        }

        public void Retrait(decimal montant, DateTime dateEffet)
        {
            Solde -= montant;
            AjoutHistorique(montant);
            AjoutHistoriqueUneSemaine(montant, dateEffet);
        }


    }
}

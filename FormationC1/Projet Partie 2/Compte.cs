using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Partie_2
{
    class Compte
    {
        public uint NumeroCompte { get; set; }
        public double Solde { get; private set; }
        public Gestionnaire Proprietaire { get; set; }

        private List<Transaction> HistoriqueTransactions = new List<Transaction>();

        public int NombreMaxDerniersRetraits { get; set; } = 10;
        public double LimiteRetraitSurPeriode { get; set; } = 2000;
        public TimeSpan PeriodeRetrait = TimeSpan.FromDays(7);

        public DateTime DateCreation { get; private set; }
        public DateTime DateResiliation { get; private set; }

        public Compte(uint numero, Gestionnaire proprietaire, double soldeInitial = 0.0)
        {
            NumeroCompte = numero;
            Proprietaire = proprietaire;
            Solde = soldeInitial;
            DateCreation = DateTime.Now;
        }

        public void Deposer(double montant)
        {
            if (!EstActif()) return;
            Solde += montant;
        }

        public bool Retirer(double montant)
        {
            if (!EstActif()) return false;

            if (Solde < montant) return false;

            if (!PeutRetirer(montant)) return false;

            Solde -= montant;
            return true;
        }

        private bool EstActif()
        {
            if (DateResiliation.HasValue && DateResiliation.Value < DateTime.Now)
            {
                return false;
            }
            return true;
        }

        public void Resilier()
        {
            DateResiliation = DateTime.Now;
        }

        public void AjouterTransactionHistorique(Transaction t)
        {
            HistoriqueTransactions.Add(t);
        }

        private bool PeutRetirer(double montant)
        {
            var retraitsRecents = HistoriqueTransactions
                .Where(t => t.Type == TypeTransaction.Retrait && t.EstReussie)
                .OrderByDescending(t => t.DateExecution)
                .Take(NombreMaxDerniersRetraits);

            var maintenant = DateTime.Now;
            var retraitsDansPeriode = HistoriqueTransactions
                .Where(t => t.Type == TypeTransaction.Retrait && t.EstReussie && t.DateExecution.HasValue)
                .Where(t => (maintenant - t.DateExecution.Value) <= PeriodeRetrait)
                .Sum(t => t.Montant);

            if (retraitsDansPeriode + montant > LimiteRetraitSurPeriode)
                return false;

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Projet_Partie_2
{
    public class Banque
    {
        private List<Compte> Comptes = new List<Compte>();
        private List<Transaction> Transactions = new List<Transaction>();
        private List<Gestionnaire> Gestionnaires = new List<Gestionnaire>();

        public int NombreComptesCrees => Comptes.Count;
        public int NombreTotalTransactions => Transactions.Count;
        public int NombreTransactionsReussies => Transactions.Count(t => t.EstReussie);
        public int NombreTransactionsEchouees => Transactions.Count(t => t.!Echoue);
        public double SommeMontantsTransactionsReussies => Transactions.Where(t => t.EstReussie).Sum(t => t.Montant);

        public void AjouterGestionnaire(Gestionnaire g)
        {
            Gestionnaires.Add(g);
        }

        public Compte CreerCompte(Gestionnaire proprietaire, double soldeInitial = 0.0)
        {
            int numero = Comptes.Count + 1;
            var compte = new Compte(numero, proprietaire, soldeInitial);
            Comptes.Add(compte);
            return compte;
        }

        public Transaction CreerTransaction(TypeTransaction type, double montant, Compte source = null, Compte destination = null)
        {
            int id = Transactions.Count + 1;
            var t = new Transaction(id, type, montant, source, destination);
            Transactions.Add(t);
            return t;
        }

        public void ExecuterTransaction(Transaction t)
        {
            t.Executer();
            if (t.EstReussie)
            {
                if (t.CompteSource != null) t.CompteSource.AjouterTransactionHistorique(t);
                if (t.CompteDestination != null) t.CompteDestination.AjouterTransactionHistorique(t);
            }
        }
    }


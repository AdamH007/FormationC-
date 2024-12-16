using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Partie_2
{
    public enum TypeTransaction
    {
        Depot,
        Retrait,
        Virement
    }
    class Transaction
    {
        public uint Id { get; private set; }
        public TypeTransaction Type { get; private set; }
        public Compte CompteSource { get; private set; }
        public Compte CompteDestination { get; private set; }
        public double Montant { get; private set; }
        public DateTime DateCreation { get; private set; }
        public DateTime DateExecution { get; private set; }
        public bool EstReussie { get; set; }
        public DateTime DateExpiration { get; private set; }

        public Transaction(uint id, TypeTransaction type, double montant, Compte source = null, Compte destination = null)
        {
            Id = id;
            Type = type;
            Montant = montant;
            CompteSource = source;
            CompteDestination = destination;
            DateCreation = DateTime.Now;
            DateExpiration = DateCreation.AddDays(7);
        }
        public void Executer()
        {
            if (DateTime.Now > DateExpiration)
            {
                EstReussie = false;
                return;
            }

            switch (Type)
            {
                case TypeTransaction.Depot:
                    if (CompteDestination != null)
                    {
                        CompteDestination.Deposer(Montant);
                        EstReussie = true;
                    }
                    break;

                case TypeTransaction.Retrait:
                    if (CompteSource != null && CompteSource.Retirer(Montant))
                    {
                        EstReussie = true;
                    }
                    break;

                case TypeTransaction.Virement:
                    if (CompteSource != null && CompteDestination != null)
                    {
                        if (CompteSource.Retirer(Montant))
                        {
                            CompteDestination.Deposer(Montant);
                            EstReussie = true;
                        }
                    }
                    break;
            }
            DateExecution = DateTime.Now;
        }
    }
}

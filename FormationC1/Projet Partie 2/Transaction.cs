using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Partie_2
{
    class Transaction
    {
        public uint IdentifiantTransaction { get; private set; }
        public decimal Montant { get; private set; }
        public uint Transmetteur { get; private set; }
        public uint Recepteur { get; private set; }
        public DateTime DateEffet { get; set; }

        public Transaction(uint identifiantTransaction, decimal montant, uint transmetteur, uint recepteur, DateTime dateEffet)
        {
            IdentifiantTransaction = identifiantTransaction;
            Montant = montant;
            Transmetteur = transmetteur;
            Recepteur = recepteur;
            DateEffet = dateEffet;
        }
    }
}

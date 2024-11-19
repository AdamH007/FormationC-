using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Partie_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var banque = new Banque();

            //Charger les comptes
            banque.ChargerComptes("Comptes.csv");

            // Charger les transactions
            banque.ChargerTransactions("Transactions.csv");
        }
    }
}

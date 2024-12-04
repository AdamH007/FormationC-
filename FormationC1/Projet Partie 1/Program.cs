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
            Banque banque = new Banque();

            //Charger les comptes
            banque.ChargerComptes("../../Comptes_1.txt");

            // Charger les transactions
            banque.ChargerTransactions("../../Transactions_1.txt");

            // Créer le fichier de sortie
            banque.effectuerToutesLesTransactions("../../StatutTransactions.csv");

            Console.ReadKey();
        }
    }
}

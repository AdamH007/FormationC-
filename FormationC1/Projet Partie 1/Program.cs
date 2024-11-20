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
            banque.ChargerComptes("../../Compte.csv");

            // Charger les transactions
            banque.ChargerTransactions("../../Transaction.csv");

            // Créer le fichier de sortie
            banque.effectuerToutesLesTransactions("../../StatutTransactions.csv");

            Console.ReadKey();
        }
    }
}

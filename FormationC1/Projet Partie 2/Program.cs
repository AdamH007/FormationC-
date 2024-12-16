using System;

namespace Projet_Partie_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Banque banque = new Banque();

            // Création de gestionnaires
            banque.AjouterGestionnaire("../../Comptes_1.txt");

            // Création de comptes
            banque.CreerCompte();

            // Création d'une transaction de virement
            banque.ExecuterTransaction();

            // Affichage des métriques
            Console.WriteLine($"Statistiques :");
            Console.WriteLine($"Nombre de comptes : {banque.NombreComptesCrees}");
            Console.WriteLine($"Nombre de transactions : {banque.NombreTotalTransactions}");
            Console.WriteLine($"Nombre de réussites : {banque.NombreTransactionsReussies}");
            Console.WriteLine($"Nombre d'échecs: {banque.NombreTransactionsEchouees}");
            Console.WriteLine($"Montant total des réussites: {banque.SommeMontantsTransactionsReussies}");

            // Arrêt du programme
            Console.ReadKey();
                
        }
    }   
}

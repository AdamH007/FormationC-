using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Projet_Partie_1
{
    class Banque
    {
        private Dictionary<uint, Compte> _comptes = new Dictionary<uint, Compte>();
        private Dictionary<uint, Transaction> _transactions = new Dictionary<uint, Transaction>();

        public Banque()
        {
        }

        private void AjouterCompte(Compte compte)
        {
            if (VerifCompteExist(compte.IdentifiantCompte))
            {
                Console.WriteLine($"Le compte {compte.IdentifiantCompte} existe déjà");
                return;
            }
            _comptes.Add(compte.IdentifiantCompte, compte);
            Console.WriteLine($"Le compte {compte.IdentifiantCompte} a bien été ajouté");
        }

        private bool VerifCompteExist(uint IdentifiantCompte)
        {
            return _comptes.ContainsKey(IdentifiantCompte);
        }

        private void AjouterTransaction(Transaction transaction)
        {
            if (VerifTransactionExist(transaction.IdentifiantTransaction))
            {
                Console.WriteLine($"La transaction {transaction.IdentifiantTransaction} existe déjà");
                return;
            }
            _transactions.Add(transaction.IdentifiantTransaction, transaction);
            Console.WriteLine($"La transaction {transaction.IdentifiantTransaction} a bien été ajoutée");
        }

        private bool VerifTransactionExist(uint IdentifiantTransaction)
        {
            return _transactions.ContainsKey(IdentifiantTransaction);
        }

        public void ChargerComptes(string input)
        {
            if (!File.Exists(input))
            {
                return;
            }

            using (FileStream file1 = File.OpenRead(input))
            using (StreamReader Comptes = new StreamReader(file1))
            {
                while (!Comptes.EndOfStream)
                {
                    string[] ligne = Comptes.ReadLine().Split(';');
                    uint identifiantCompte;
                    decimal solde;
                    if (ligne.Length == 2 && uint.TryParse(ligne[0], out identifiantCompte) && identifiantCompte != 0 && (decimal.TryParse(ligne[1],NumberStyles.AllowDecimalPoint,CultureInfo.GetCultureInfo("en-US"), out solde) || ligne[1] == string.Empty))
                    {
                        if (ligne[1] == string.Empty)
                        {
                            solde = 0;
                        }
                        Compte compte = new Compte(identifiantCompte, solde);
                        AjouterCompte(compte);
                    }
                }
            }
        }

        public void ChargerTransactions(string input)
        {
            if (!File.Exists(input))
            {
                Console.Write("fichier existe pas");
                return;
            }

            using (FileStream file2 = File.OpenRead(input))
            using (StreamReader Transactions = new StreamReader(file2))
            {
                while (!Transactions.EndOfStream)
                {
                    string[] ligne = Transactions.ReadLine().Split(';');
                    uint identifiantCompte;
                    decimal solde;
                    uint transmetteur;
                    uint recepteur;
                    if (ligne.Length == 4 && uint.TryParse(ligne[0], out identifiantCompte) && decimal.TryParse(ligne[1], NumberStyles.AllowDecimalPoint, CultureInfo.GetCultureInfo("en-US"), out solde) && uint.TryParse(ligne[2], out transmetteur) && uint.TryParse(ligne[3], out recepteur))
                    {
                        Transaction transaction = new Transaction(identifiantCompte, solde, transmetteur, recepteur);
                        AjouterTransaction(transaction);
                    }
                }
            }
        }

        public void effectuerToutesLesTransactions(string output)
        {
            using (FileStream file3 = File.Create(output))
            using (StreamWriter sortie = new StreamWriter(file3))
            {
                foreach (Transaction transaction in _transactions.Values)
                {

                    if (!effectuerUneTransaction(transaction))
                    {
                        sortie.WriteLine($"{transaction.IdentifiantTransaction};KO");
                    }
                    else
                    {
                        sortie.WriteLine($"{transaction.IdentifiantTransaction};OK");

                    }
                }
            }    
        }

        private bool effectuerUneTransaction(Transaction transaction)
        {
            if (!VerifCompteExist(transaction.Transmetteur) & transaction.Transmetteur != 0 || !VerifCompteExist(transaction.Recepteur)  & transaction.Recepteur != 0)
            {
                Console.WriteLine("Un des comptes n'existe pas");
                return false;
            }

            Compte transmetteur;
            Compte recepteur;

            if (transaction.Transmetteur == 0)
            {
                recepteur = _comptes[transaction.Recepteur];
                if (recepteur.VerifDepot(transaction.Montant))
                {
                    recepteur.Depot(transaction.Montant);
                    return true;
                }
                return false;
            }

            if (transaction.Recepteur == 0)
            {
                transmetteur = _comptes[transaction.Transmetteur];
                if(transmetteur.VerifRetrait(transaction.Montant))
                {
                    transmetteur.Retrait(transaction.Montant);
                    return true;
                }
                return false;
            }

            transmetteur = _comptes[transaction.Transmetteur];
            recepteur = _comptes[transaction.Recepteur];

            if (transmetteur.VerifRetrait(transaction.Montant) && recepteur.VerifDepot(transaction.Montant))
            {
                transmetteur.Retrait(transaction.Montant);
                recepteur.Depot(transaction.Montant);
                return true;
            }           
            return false;
        }
    }
}

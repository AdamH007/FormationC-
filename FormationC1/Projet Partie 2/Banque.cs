using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Projet_Partie_2
{
    class Banque
    {
        private Dictionary<uint, Compte> _comptes;
        private Dictionary<uint, Gestionnaire> _gestionnaires;
        private int _compteurComptes;
        private int _compteurTransactions;
        private int _compteurReussites;
        private int _compteurEchecs;
        private decimal _montantTotalDesReussites;


        public Banque()
        {
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
                    if (ligne.Length == 2 && uint.TryParse(ligne[0], out identifiantCompte) && identifiantCompte != 0 && (decimal.TryParse(ligne[1], NumberStyles.AllowDecimalPoint, CultureInfo.GetCultureInfo("en-US"), out solde) || ligne[1] == string.Empty))
                    {
                        if (ligne[1] == string.Empty)
                        {
                            solde = 0;
                        }
                        //Compte compte = new Compte(identifiantCompte, solde);
                        //AjouterCompte(compte);
                    }
                }
            }
        }

        public void ChargerGestionnaires(string input)
        {
            if (!File.Exists(input))
            {
                return;
            }

            using (FileStream file2 = File.OpenRead(input))
            using (StreamReader Gestionnaires = new StreamReader(file2))
            {
                while (!Gestionnaires.EndOfStream)
                {
                    string[] ligne = Gestionnaires.ReadLine().Split(';');
                    uint identifiantGestionnaire;
                    int nombreTransMaxRetrait;
                    if (ligne.Length == 3 && uint.TryParse(ligne[0], out identifiantGestionnaire) && identifiantGestionnaire != 0 && ligne[1] == "Entreprise" || ligne[1] == "Particulier" && int.TryParse(ligne[2], out nombreTransMaxRetrait) || nombreTransMaxRetrait < 0)
                    {
                        Gestionnaire gestionnaire = new Gestionnaire(identifiantGestionnaire, ligne[1], nombreTransMaxRetrait);
                        //AjouterGestionnaire(gestionnaire);
                    }
                }
            }
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

        private void AjouterGestionnaire(Gestionnaire gestionnaire)
        {
            if (VerifGestionnaireExist(gestionnaire.IdentifiantGestionnaire))
            {
                Console.WriteLine($"Le gestionnaire {gestionnaire.IdentifiantGestionnaire} existe déjà");
                return;
            }
            _gestionnaires.Add(gestionnaire.IdentifiantGestionnaire, gestionnaire);
            Console.WriteLine($"Le gestionnaire {gestionnaire.IdentifiantGestionnaire} a bien été ajouté");
        }

        private bool VerifGestionnaireExist(uint IdentifiantGestionnaire)
        {
            return _comptes.ContainsKey(IdentifiantGestionnaire);
        }

       /* private void AjouterTransaction(Transaction transaction)
        {
            if (VerifTransactionExist(transaction.IdentifiantTransaction))
            {
                Console.WriteLine($"La transaction {transaction.IdentifiantTransaction} existe déjà");
                return;
            }
            //_transactions.Add(transaction.IdentifiantTransaction, transaction);
            Console.WriteLine($"La transaction {transaction.IdentifiantTransaction} a bien été ajoutée");
        }

        private bool VerifTransactionExist(uint IdentifiantTransaction)
        {
            return _transactions.ContainsKey(IdentifiantTransaction);
        }*/
    }
}


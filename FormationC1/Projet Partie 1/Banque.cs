using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Projet_Partie_1
{
    class Banque
    {
        private Dictionary<uint, Compte> _comptes = new Dictionary<uint, Compte>();
        private Dictionary<uint, Transaction> _transactions = new Dictionary<uint, Transaction>();

        public bool AjouterCompte(Compte compte)
        {
            if (_comptes.ContainsKey(compte.IdentifiantCompte))
            {
                return false;
            }
            _comptes.Add(compte.IdentifiantCompte, compte);
            return true;
        }

        public bool VerifCompteExist(uint IdentifiantCompte)
        {
            return _comptes.ContainsKey(IdentifiantCompte);
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
                    if (!_comptes.ContainsKey(ligne[1]))
                    {
                        
                    }
                }
            }
        }
        public void ChargerTransactions(string input)
        {
            if (!File.Exists(input))
            {
                return;
            }

            using (FileStream file2 = File.OpenRead(input))
            using (StreamReader Transactions = new StreamReader(file2))
            {
                while (!Transactions.EndOfStream)
                {
                    string[] ligne = Transactions.ReadLine().Split(';');
                    if (!_transactions.ContainsKey(ligne[1]))
                    {
                        
                    }
                }
            }
        }
    }
}

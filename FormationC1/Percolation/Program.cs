using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Implémentaion
3.b : Le pire cas de cette méthode c'est quand on doit ouvrir toutes les cases d'une grille
où toute la première ligne est bloquée sauf celle de l'extrémité.
3.c : C'est quasiment impossible vu qu'on peut ouvrir aléatoirement.
 */

namespace Percolation
{
    class Program
    {
        static void Main(string[] args)
        {
            Percolation grille = new Percolation(4);

            grille.CloseNeighbors(7, 7);
            List<KeyValuePair<int, int>> neighbors = grille.CloseNeighbors(0, 0);
            Console.WriteLine(neighbors);

            for (int i = 0; i < neighbors.Count; i++)
            {
                Console.Write(neighbors[i].Key + " ");
                Console.Write(neighbors[i].Value);
                Console.WriteLine();
            }
            

            Console.ReadKey();
        }
    }
}

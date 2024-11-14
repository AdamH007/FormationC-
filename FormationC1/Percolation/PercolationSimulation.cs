using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    public struct PclData
    {
        /// <summary>
        /// Moyenne 
        /// </summary>
        public double Mean { get; set; }
        /// <summary>
        /// Ecart-type
        /// </summary>
        public double StandardDeviation { get; set; }
        /// <summary>
        /// Fraction
        /// </summary>
        public double Fraction { get; set; }
    }

    public class PercolationSimulation
    {
        public PclData MeanPercolationValue(int size, int t)
        {
            return new PclData();
        }

        public double PercolationValue(int size)
        {
            int CasesOuvertes = 0;
            var percolation = new Percolation(size);
            var random = new Random();
            int TotalCases = size * size;

            while (!percolation.Percolate())
            {
                int random1 = random.Next(0, size);
                int random2 = random.Next(0, size);

                if (!percolation.IsOpen(random1, random2))
                {
                    // J'utilise la fonction Open même si j'ai pas réussi à la créer
                    percolation.Open(random1, random2);
                    CasesOuvertes++;
                }
            }
            return CasesOuvertes / TotalCases;
        }
    }
}

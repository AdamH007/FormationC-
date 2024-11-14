using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    public class Percolation
    {
        private readonly bool[,] _open;
        private readonly bool[,] _full;
        private readonly int _size;
        private bool _percolate;

        public Percolation(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), size, "Taille de la grille négative ou nulle.");
            }

            _open = new bool[size, size];
            _full = new bool[size, size];
            _size = size;
        }

        public bool IsOpen(int i, int j)
        {
            if (_open[i, j] == true)
            {
                return true;
            }
            return false;
        }

        private bool IsFull(int i, int j)
        {
            if (_full[i, j] == true)
            {
                return true;
            }
            return false;
        }

        public bool Percolate()
        {
            if (_percolate)
            {
                return true;
            }
            for (int i = 0; i < _size; i++)
            {
                if (_full[_size - 1,i] == true)
                {
                    return true;
                }
            }
            return false;
        }

        public List<KeyValuePair<int, int>> CloseNeighbors(int i, int j)
        {
            List<KeyValuePair<int, int>> neighbor = new List<KeyValuePair<int, int>>();

            if (i  >= 1)
            {
                neighbor.Add(new KeyValuePair<int, int>(i - 1, j));
            }
            if (j  >= 1)
            {
                neighbor.Add(new KeyValuePair<int, int>(i, j - 1));
            }
            if (i  < _size - 1)
            {
                neighbor.Add(new KeyValuePair<int, int>(i + 1, j));
            }
            if (j  < _size - 1)
            {
                neighbor.Add(new KeyValuePair<int, int>(i, j + 1));
            }
            return neighbor;
        }

        public void Open(int i, int j)
        {
            List<KeyValuePair<int, int>> neighbor = new List<KeyValuePair<int, int>>();

            _open[i, j] = true;

            if (i == 0)
            {
                _full[i, j] = true;
            }
            // j'ai la logique de comment ça fonctionne mais je sais pas comment la coder          
        }
    }
}

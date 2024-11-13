using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cours_Series
{
    class Program
    {
        //Fonction d'affichage de la matrice
        static void DisplayMatrix(int[,] matrice)
        {
            if (matrice == null)
            {
                Console.WriteLine("Multiplication impossible");
                return;
            }
            for (int i = 0; i < matrice.GetLength(0); i++)
            {
                for (int j = 0; j < matrice.GetLength(1); j++)
                {
                    Console.Write($"{matrice[i, j]}  ");   
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            BasicOperation(3, 4, '+');
            BasicOperation(6, 2, '/');
            BasicOperation(3, 0, '/');
            BasicOperation(6, 9, 'L');

            Console.WriteLine();

            IntegerDivision(12, -4);
            IntegerDivision(13, -4);
            IntegerDivision(12, 0);

            Console.WriteLine();

            Pow(2, 4);
            Pow(4, -2);

            Console.WriteLine();

            GoodDay(5);
            GoodDay(10);
            GoodDay(12);
            GoodDay(15);
            GoodDay(20);

            Console.WriteLine();

            PyramidConstruction(10, false);

            Console.WriteLine();

            Console.WriteLine(Factorial(5) + "\n");

            Console.WriteLine(FactorialRec(7) + "\n");

            int[] tableau = new int[] { 1, -5, 10, -3, 0, 4, 2, -7 };
            Console.WriteLine(LinearSearch(tableau, 1) + "\n");

            int[] tableauTri = new int[] { -7, -5, -3, 0, 1, 2, 4, 10 };
            Console.WriteLine(BinarySearch(tableauTri, -8) + "\n");

            int[] leftVector = new int[] { 1, 2, 3 };
            int[] rightVector = new int[] { -1, -4, 0 };
            int[,] matrice = BuildingMatrix(leftVector,rightVector);
            DisplayMatrix(matrice);

            int[,] leftMatrix = new int[,] { { 1, 2 }, { 4, 6 }, { -1, 8 } };
            int[,] rightMatrix = new int[,] { { -1, 5 }, { -4, 0 }, { 0, 2 } };
            int[,] amatrix = Addition(leftMatrix, rightMatrix);
            DisplayMatrix(amatrix);

            int[,] smatrix = Substraction(leftMatrix, rightMatrix);
            DisplayMatrix(smatrix);

            int[,] mleftMatrix = new int[,] { { 1, 2 }, { 4, 6 }, { -1, 8 } };
            int[,] mrightMatrix = new int[,] { { -1, 5, 0 }, { -4, 0, 1 } };
            int[,] mmatrix = Multiplication(mleftMatrix, mrightMatrix);
            DisplayMatrix(mmatrix);

            SchoolMeans("../../Files/notes.csv", "../../Files/moyenne.csv");

            Console.ReadKey();
            
            


        }
        // SérieI
        // Exercice 1 : Opérations de base
        static void BasicOperation(int a, int b, char operateur)
        {
            int r;
            switch (operateur)
            {
                case '+':
                    r = a + b;
                    Console.WriteLine(a + " " + operateur + " " + b + " = " + r);
                    break;
                case '-':
                    r = a - b;
                    Console.WriteLine(a + " " + operateur + " " + b + " = " + r);
                    break;
                case '*':
                    r = a * b;
                    Console.WriteLine(a + " " + operateur + " " + b + " = " + r);
                    break;
                case '/':
                    if (b == 0)
                    {
                        Console.WriteLine(a + " " + operateur + " " + b + " = " + "Opération invalide");
                        break;
                    }
                    else
                    {
                        r = a / b;
                        Console.WriteLine(a + " " + operateur + " " + b + " = " + r);
                        break;
                    }
                default:
                    Console.WriteLine(a + " " + operateur + " " + b + " = " + "Opération invalide");
                    break;

            }

        }
        // Exercice 1 : Division entière
        static void IntegerDivision(int a, int b)
        {
            int q; int r;

            if (b == 0)
            {
                Console.WriteLine($"{a} : {b} = Opération invalide");
                return;
            }
             
            r = a % b;
            q = a / b;
            
            if (r == 0)
            {
                a = q * b + r;
                Console.WriteLine($"{a} = {q} * {b}");

            }
            else
            {
                a = q * b + r;
                Console.WriteLine($"{a} = {q} * {b} + {r}");
            }
                

        }
        // Exercice 1 : Puissance entière
        static void Pow(int a, int b)
        {
            int r;

            if (b < 0)
            {
                Console.WriteLine($"{a} ^ {b} = Opération invalide");
            }
            else
            {
                r = (int) Math.Pow(a, b);
                Console.WriteLine($"{a} ^ {b} = {r}");
            }
        }
        // Exercice 2 : Horloge parlante
        static void GoodDay(int heure)
        {
            if (heure >= 0 && heure < 6)
            {
                Console.WriteLine($"Il est {heure} H, Merveulleuse nuit!");
            }
            else if (heure >= 6 && heure < 12)
            {
                Console.WriteLine($"Il est {heure} H, Bonne matinée!");
            }
            else if (heure == 12)
            {
                Console.WriteLine($"Il est {heure} H, Bon appétit!");
            }
            else if (heure >= 13 && heure <= 18)
            {
                Console.WriteLine($"Il est {heure} H, Profitez de votre après-midi!");
            }
            else if (heure > 18 && heure < 24)
            {
                Console.WriteLine($"Il est {heure} H, Passez une bonne soirée!");
            }
        }
        // Exercice 3 : Construction d'une pyramide
        static void PyramidConstruction(int n, bool isSmooth)
        {
            if (isSmooth)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(new string(' ', n - j - 1));
                    Console.Write(new string('+', j * 2 + 1));
                    Console.WriteLine();
                }
            }
            else
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(new string(' ', n - j - 1));

                    if (j % 2 == 0)
                    {
                        Console.Write(new string('+', j * 2 + 1));
                        Console.WriteLine();
                    }
                    else 
                    {
                        Console.Write(new string('-', j * 2 + 1));
                        Console.WriteLine();
                    }

                }
            }
           
        }
        // Exercice 4 : Factorielle
        // Première question
        static int Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            int r = 1;
            for (int i = 1; i <= n; i++)
            {
                r *= i;              
            }
            return r;
        }
        // Exercice 4 : Factorielle
        // Deuxième question
        static int FactorialRec(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }
            return n * FactorialRec(n - 1);
        }
        // Série II
        // Exercice 1 : Recherche d'un élément
        // Recherche linéaire
        static int LinearSearch(int[] tableau, int valeur)
        {
            for (int i = 0; i < tableau.Length; i++)
            {
                if ( valeur == tableau[i])
                {
                    return i;
                }
            }
            return -1;
        }
        // Exercice 1 : Recherche d'un élément
        // Recherche dichotomique
        static int BinarySearch(int[] tableau, int valeur)
        {
            int a = 0;
            int b = tableau.Length;

            if (b == 0)
            {
                return -1;
            }

            while (b > a)
            {
                int m = (a + b) / 2;
                if (tableau[m] == valeur)
                {
                    return m;
                }
                else if (tableau[m] > valeur )
                {
                    b = m - 1;
                }
                else 
                {
                    a = m + 1;
                }
            }
            return -1;
        }
        // Exercice 2 : Bases du calcul matriciel
        // Construction matricielle
        static int[,] BuildingMatrix(int[] leftVector, int[] rightVector)
        {
            int[,] matrice = new int[leftVector.Length,rightVector.Length] ;

            for (int i = 0; i < leftVector.Length; i++)
            {
                for (int j = 0; j < rightVector.Length; j++)
                {
                    matrice[i,j] = leftVector[i] * rightVector[j];
                }
            }
            return matrice;
        }
        // Exercice 2 : Bases du calcul matriciel
        // Addition
        static int[,] Addition(int[,] leftMatrix, int[,] rightMatrix)
        {
            int[,] amatrix = new int[leftMatrix.GetLength(0), rightMatrix.GetLength(1)];

            for (int i = 0; i < leftMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < leftMatrix.GetLength(1); j++)
                {
                    amatrix[i, j] = leftMatrix[i,j] + rightMatrix[i,j];
                }
            }
            return amatrix;
        }
        // Exercice 2 : Bases du calcul matriciel
        // Soustraction
        static int[,] Substraction(int[,] leftMatrix, int[,] rightMatrix)
        {
            int[,] smatrix = new int[leftMatrix.GetLength(0), rightMatrix.GetLength(1)];

            for (int i = 0; i < leftMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < leftMatrix.GetLength(1); j++)
                {
                    smatrix[i, j] = leftMatrix[i, j] - rightMatrix[i, j];
                }
            }
            return smatrix;
        }
        // Exercice 2 : Bases du calcul matriciel
        // Multiplication
        static int[,] Multiplication(int[,] leftMatrix, int[,] rightMatrix)
        {
            int[,] mmatrix = new int[leftMatrix.GetLength(0), rightMatrix.GetLength(1)];

            for (int i = 0; i < leftMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < leftMatrix.GetLength(1); j++)
                {
                    if (i != j)
                    {
                        return null;
                    }
                    else
                    {
                        mmatrix[i, j] = leftMatrix[i, j] * rightMatrix[i, j];
                    }
                }
            }
            return mmatrix;
        }
        // Série III
        // Exercice 1 : Conseil de classe
        static void SchoolMeans(string input, string output)
        {
            if (!File.Exists(input))
            {
                return;
            }
            // Dictionnaire pour les matières et la somme des notes
            Dictionary<string, double> dict1 = new Dictionary<string, double>();
            // Dictionnaire pour les matières et le nombre des notes
            Dictionary<string, int> dict2 = new Dictionary<string, int>();
            // Ouvrir le fichier
            using (FileStream file1 = File.OpenRead(input))
            // Déclaration de l'outil qui sert à lire le fichier
            using (StreamReader file2 = new StreamReader(file1))
            {
                while (!file2.EndOfStream)
                {
                    string[] ligne = file2.ReadLine().Split(';');
                    if (dict1.ContainsKey(ligne[1]))
                    {
                        dict1[ligne[1]] += double.Parse(ligne[2]);
                        dict2[ligne[1]]++;
                    }
                    else
                    {
                        dict1.Add(ligne[1], double.Parse(ligne[2]));
                        dict2.Add(ligne[1], 1);
                    }
                }
            }
            // Création du fichier de sortie et calcul de la moyenne
            using (FileStream file3 = File.Create(output))
            using (StreamWriter file4 = new StreamWriter(file3))
            {
                foreach (KeyValuePair<string, double> item in dict1)
                {
                    double moy = item.Value / dict2[item.Key];
                    file4.WriteLine($"{item.Key};{moy:0.0}");
                }
            }

        }
    }


}

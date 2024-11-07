using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cours_Series
{
    class Program
    {
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

            Console.ReadKey();
            
            


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
    }


}

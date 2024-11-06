using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cours_Series
{
    class Program
    {
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
            IntegerDivision(12, -4);
            IntegerDivision(13, -4);
            IntegerDivision(12, 0);
            Pow(2, 4);
            Pow(4, -2);
            GoodDay(5);
            GoodDay(10);
            GoodDay(12);
            GoodDay(15);
            GoodDay(20);
            Console.ReadKey();
            
            


        }
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
        
    }   
    

}

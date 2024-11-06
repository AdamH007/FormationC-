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
            Console.ReadKey();
            
            


        }
        static void IntegerDivision(int a, int b)
        {
            int q; int r;

            if (b == 0)
            {
                Console.WriteLine($"{a} : {b} = Opération invalide");
            }
             
            r = a % b;
            q = a / b;
            
            if (r == 0)
            {
                a = q * b + r;
                Console.WriteLine($"{a} = {q} * {b}");

            }
            else
            {r = a % b;
                a = q * b + r;
                Console.WriteLine($"{a} = {q} * {b} + {r}");
            }
                

        }
    }     

}

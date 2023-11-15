using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool start = false;
            DoubleTryPars doubleTryPars = new DoubleTryPars();
            string[] array = new string[2];
            double[] doubleArray = new double[2];
            Calc calc = new Calc();

            while (!start)
            {
                Console.WriteLine("Enter the first number");

                array[0] = Console.ReadLine();

                Console.WriteLine("Enter a mathematical operation");

                string operation = Console.ReadLine();

                Console.WriteLine("Enter the second number");

                array[1] = Console.ReadLine();
                try
                {
                    doubleArray = doubleTryPars.TryParsDouble(array);

                    switch (operation)
                    {
                        case "+":
                            calc.Sum(doubleArray[0], doubleArray[1]);
                            break;
                        case "-":
                            calc.Sub(doubleArray[0], doubleArray[1]);
                            break;
                        case "/":
                            calc.Divide(doubleArray[0], doubleArray[1]);
                            break;
                        case "*":
                            calc.Multy(doubleArray[0], doubleArray[1]);
                            break;
                        default:
                            Console.WriteLine("I am not aware of such operations");
                            break;

                    }
                }
                catch (NegativeNumberException ex)
                {
                    Console.WriteLine();
                    Console.WriteLine(ex.Message);
                }catch (Exception ex) 
                {
                    Console.WriteLine();
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine();

            }
        }
    }
}

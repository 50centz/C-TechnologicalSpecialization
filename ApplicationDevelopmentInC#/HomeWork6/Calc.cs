using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6
{
    internal class Calc
    {
        public void Divide(double first, double second)
        {
            if(second == 0)
            {
                throw new DivideByZeroException("You can't divide by zero");
            }
            else
            {
                Console.WriteLine("\nResult: " + (first / second));
            }
            
        }

        public void Multy(double first, double second)
        {
            Console.WriteLine();
            Console.WriteLine("\nResult: " + (first * second));
        }

        public void Sub(double first, double second)
        {
            double result = first - second;
            if(result < 0)
            {
                throw new NegativeNumberException("The result is negative");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("\nResult: " + result);
            }
        }

        public void Sum(double first, double second)
        {
            Console.WriteLine();
            Console.WriteLine("\nResult: " + (first + second));
        }
    }
}

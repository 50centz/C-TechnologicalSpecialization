using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4
{
    internal class Print
    {
        public static void PrintArray(int first, int second, int third, int target)
        {
            Console.WriteLine($"{first} + {second} + {third} = {target}");
        }

        public static void PrintArray1<T>( T first, T second, T third)
        {
            Console.WriteLine($"{first} + {second} + {third}");
        }
    }
}

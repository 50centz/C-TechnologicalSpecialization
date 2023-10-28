using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Дан массив и число.
            // Найдите три числа в массиве сумма которых равна искомому числу.
            // Подсказка: если взять первое число в массиве, можно ли найти в оставшейся его части два числа равных по сумме первому.

            int[] numbers = new int[100];

            for (int i = 1; i < numbers.Length; i++)
            {
                numbers[i] = i;
            }

            List<int> list = new List<int>();
            foreach (int i in numbers)
            {
                list.Add(i);
            }

            list.MyWhere<int>((x, y, z) => x + y + z == 120);
            FindNumbers.Find(numbers, 70);

            Console.ReadKey();
        }
    }
}

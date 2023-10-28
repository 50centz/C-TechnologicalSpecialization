using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4
{
    internal class FindNumbers
    {
        public static void Find(int[] array, int find)
        {
            foreach (int i in array)
            {
                foreach(int j in array)
                {
                    foreach (int z in array)
                    {
                        if (i + j + z == find)
                        {
                            Print.PrintArray(i, j, z, find);
                        }
                    }
                }
            }
        }


    }
}

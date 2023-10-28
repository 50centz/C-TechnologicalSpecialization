using System;
using System.Collections.Generic;

namespace HomeWork4
{
    internal static class Test
    {
        public static void MyWhere<T>(this IEnumerable<T> values, Func<T, T, T, bool> predicate)
        {
            foreach (var value1 in values)
            {
                foreach(var value2 in values)
                {
                    foreach(var value3 in values)
                    {
                        if (predicate(value1, value2, value3))
                        {
                            Print.PrintArray1(value1, value2, value3);
                        }
                    }
                }   
            }
        }
    }
}

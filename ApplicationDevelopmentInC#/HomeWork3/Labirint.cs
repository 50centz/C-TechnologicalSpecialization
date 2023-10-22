using System;
using System.Collections.Generic;

namespace HomeWork3
{
    internal class Labirint
    {
        
        public static int HasExit(int startI, int startJ, int[,] l)
        {
            int count = 0;

            if (l[startI, startJ] == 1)
            {
                Console.WriteLine("Начали с стены");
                return count;
            }

            if (l[startI, startJ] == 2)
            {
                count = +1;
            }

            Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();

            stack.Push(new Tuple<int, int>(startJ, startI));

            while (stack.Count > 0)
            {
                var tmp = stack.Pop();

                if (l[tmp.Item1, tmp.Item2] == 2)
                {
                    count++;
                }

                l[tmp.Item1, tmp.Item2] = 1;

                if (tmp.Item2 == 0 && l[tmp.Item1 - 1, tmp.Item2] != 1)
                    stack.Push(new Tuple<int, int>(tmp.Item1 - 1, tmp.Item2));
                if (tmp.Item2 == 0 && l[tmp.Item1 + 1, tmp.Item2] != 1)
                    stack.Push(new Tuple<int, int>(tmp.Item1 + 1, tmp.Item2));
                if (tmp.Item2 == 0 && l[tmp.Item1, tmp.Item2 + 1] != 1)
                    stack.Push(new Tuple<int, int>(tmp.Item1, tmp.Item2 + 1));


                if (tmp.Item2 > 0 && tmp.Item2 + 1 < l.GetLength(1) && l[tmp.Item1, tmp.Item2 + 1] != 1)
                    stack.Push(new Tuple<int, int>(tmp.Item1, tmp.Item2 + 1));
                if (tmp.Item2 > 0 && tmp.Item1 - 1 > 0 && l[tmp.Item1 - 1, tmp.Item2] != 1)
                    stack.Push(new Tuple<int, int>(tmp.Item1 - 1, tmp.Item2));
                if (tmp.Item2 > 0 && tmp.Item1 + 1 < l.GetLength(0) && l[tmp.Item1 + 1, tmp.Item2] != 1)
                    stack.Push(new Tuple<int, int>(tmp.Item1 + 1, tmp.Item2));

            }


            return count;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    internal class Calc : ICalc
    {
        public double Result { get; set; } = 0;
        private Stack<double> LastResult { get; set; } = new Stack<double>();

        public event EventHandler<EventArgs> MyEventHandler;

        private void PrintResult()
        {
            MyEventHandler?.Invoke(this, new EventArgs());
        }

        public void Divide(int x)
        {
            Result /= x;
            PrintResult();
            LastResult.Push(Result);
        }

        public void Multy(int x)
        {
            Result *= x;
            PrintResult();
            LastResult.Push(Result);
        }

        public void Sub(int x)
        {
            Result -= x;
            PrintResult();
            LastResult.Push(Result);
        }

        public void Sum(int x)
        {
            Result += x;
            PrintResult();
            LastResult.Push(Result);
        }

        public void Clear1()
        {
            LastResult.Clear();
            Result = 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    internal interface ICalc
    {
        double Result { get; set; }
        void Sum(int x);
        void Sub(int x);
        void Multy(int x);
        void Divide(int x);

        event EventHandler<EventArgs> MyEventHandler;

    }
}

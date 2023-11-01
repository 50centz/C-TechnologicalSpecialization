using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    internal class Program
    {
        //Доработайте программу калькулятор реализовав выбор действий и вывод результатов на экран
        //в цикле так чтобы калькулятор мог работать до тех пор пока пользователь не нажмет отмена или введёт пустую строку.
        static void Main(string[] args)
        {
            Calc calc = new Calc();
            calc.MyEventHandler += Calc_MyEventHandler;

            bool start = false;


            while (!start)
            {
                Console.WriteLine("Enter the first number");

                string number1 = Console.ReadLine();

                Console.WriteLine("Enter a mathematical operation");

                string operation = Console.ReadLine();

                Console.WriteLine("Enter the second number");

                string number2 = Console.ReadLine();


                int number11;
                int number22;

                bool isNUmber1 = int.TryParse(number1, out number11);
                bool isNumber2 = int.TryParse(number2, out number22);

                if (!isNUmber1)
                {
                    number1.ToLower();
                    if (number1.Equals("Отмена"))
                    {
                        start = true;
                    }
                }
                else if (isNUmber1 && isNumber2)
                {

                    switch (operation)
                    {
                        case "+":
                            calc.Sum(number11);
                            calc.Sum(number22);
                            calc.Clear1();
                            break;
                        case "-":
                            calc.Sum(number11);
                            calc.Sub(number22);
                            calc.Clear1();
                            break;
                        case "/":
                            calc.Sum(number11);
                            if (number22 == 0)
                            {
                                Console.WriteLine("You can't divide by zero");
                                break;
                            }
                            calc.Divide(number22);
                            calc.Clear1();
                            break;
                        case "*":
                            calc.Sum(number11);
                            calc.Multy(number22);
                            calc.Clear1();
                            break;
                        default:
                            Console.WriteLine("I am not aware of such operations");
                            break;

                    }
                }
            }

           
        }


        private static void Calc_MyEventHandler(object sender, EventArgs e)
        {
            if (sender is Calc)
            {
                Console.WriteLine(((Calc)sender).Result);
            }
        }
    }
}

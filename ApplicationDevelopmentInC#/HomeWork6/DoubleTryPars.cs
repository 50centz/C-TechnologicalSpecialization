using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6
{
    internal class DoubleTryPars 
    {
        public double[] TryParsDouble(string[] numbers)
        {
            double[] result = new double[2];
            try
            {
           
                double first = double.Parse(numbers[0]);
                double second = double.Parse(numbers[1]);

                if (first < 0 || second < 0)
                {
                    throw new NegativeNumberException("The number is negative");
                }
                result[0] = first;
                result[1] = second;
            }catch (NegativeNumberException e)
            {
                throw new NegativeNumberException("The number is negative");
            }
            catch (Exception e)
            {
                throw new NegativeNumberException("The number is negative");
            }
            return result;
        }
    }
}

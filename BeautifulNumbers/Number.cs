using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeautifulNumbers
{
   public class Number
    {
        public readonly int CalcSystem;

        public List<double> Digits;

        public readonly double MaxSum;

        public Number(int system, int count)
        {
            Inizialize(count);
            CalcSystem = system;
            MaxSum = (system - 1) * count;
        }

        private void Inizialize(int count)
        {
            Digits = new List<double>();
            for(var i = 0; i < count; i++)
            {
                Digits.Add(0.0);
            }
        }

        public double Sum() => Digits.Sum();

        public bool IsLucky(int comb)
        {
            var fist_sum = Digits.Take(comb).Sum();
            var second_sum = Digits.TakeLast(comb).Sum();

            return fist_sum == second_sum;
        }

        private bool GrowDigit(int position)
        {
            var next_val = Digits[position] + 1;

            if (next_val < CalcSystem)
            {
                Digits[position] = next_val;
                return true;
            }
            else
            {
                return false;
            }
        }


        public void Increace()
        {
            if (this.Sum() != MaxSum)
            {
                var i = Digits.Count - 1;

                while (!GrowDigit(i))
                {
                    Digits[i] = 0;
                    i--;
                }
            }
        }
    }
}

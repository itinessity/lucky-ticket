using System;

namespace BeautifulNumbers
{
    class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("Задача о счастливых билетах");
            Console.WriteLine("Решение перебором испольовалось только для проверки комбинаторного решения на малых выборках.");
            Console.WriteLine("Решение перебором на количестве цифр > 6 показывает плохой результат");
            Console.WriteLine();

            Console.WriteLine("10-тиричная система, сумма 2х элементов, билет 4 цифр");

            SimpleButeForce(10, 4, 2);
            CombinatoricWay(10, 4.0, 2.0);

            Console.WriteLine();

            Console.WriteLine("10-тиричная система, сумма 3х элементов, билет 6 цифр");

            SimpleButeForce(10, 6, 3);
            CombinatoricWay(10, 6.0, 3.0);

            Console.WriteLine();

            Console.WriteLine("13-тиричная система, сумма 3х элементов, билет 6 цифр");

            SimpleButeForce(13, 6, 3);
            CombinatoricWay(13, 6.0, 3.0);

            Console.WriteLine();

            Console.WriteLine("10-тиричная система, сумма 6х элементов, билет 12 цифр");

        
            CombinatoricWay(10, 12.0, 6.0);

            Console.WriteLine();

            Console.WriteLine("10-тиричная система, сумма 6х элементов, билет 13 цифр");


            CombinatoricWay(10, 13.0, 6.0);

            Console.WriteLine();

            Console.WriteLine("13-тиричная система, сумма 6х элементов, билет 13 цифр");


            CombinatoricWay(13, 13.0, 6.0);

            Console.WriteLine();


            Console.ReadKey();
        }



        public static void CombinatoricWay(int SystemCalc, double TicketLengh, double LuckyComb)
        {
            Console.WriteLine("Решение комбинаторным путем:");
            //Источник решения: https://neerc.ifmo.ru/wiki/index.php?title=%D0%97%D0%B0%D0%B4%D0%B0%D1%87%D0%B0_%D0%BE_%D1%81%D1%87%D0%B0%D1%81%D1%82%D0%BB%D0%B8%D0%B2%D1%8B%D1%85_%D0%B1%D0%B8%D0%BB%D0%B5%D1%82%D0%B0%D1%85

            //количество счастливых цифр билета
            var n = LuckyComb;

            //длина билета
            var ticket_lengh = TicketLengh;


            var min = 0;
            var max = Math.Round(Convert.ToDouble((SystemCalc * n) / SystemCalc), 0);

            var sum = 0.0;
            for (int j = min; j < max; j++)
            {
                //var value = Math.Pow(-1, j) * CalcCombination(ticket_lengh, j) * CalcCombination((k + 2) * n - (k + 1) * j - 1, k * n - (k + 1) * j);
                //sum += value;

                var value = Math.Pow(-1, j) * CalcCombination(ticket_lengh, j) * CalcCombination((SystemCalc-1)* LuckyComb + ticket_lengh - 1 - SystemCalc*j, ticket_lengh - 1);
                sum += value;
            }


            Console.WriteLine(Math.Round(sum));

        }


        public static double CalcCombination(double a, double b)
        {
            return Factorial(a) / (Factorial(b) * Factorial(a - b));
        }

        public static double Factorial(double n)
        {
            double res = 1;

            if (n != 0)
            {
                while (n != 1)
                {
                    res *= n;
                    n -= 1;
                }
            }
            return res;
        }


        public static void SimpleButeForce(int SystemCalc, int TicketLengh, int LuckyComb)
        {
            Console.WriteLine("Решение простым перебором:");

            //учитывать билет со всеми 0
            var count = 1;

            var num = new Number(SystemCalc, TicketLengh);

            while (num.Sum() != num.MaxSum)
            {
                if (num.IsLucky(LuckyComb))
                {
                    count++;
                }
                
                num.Increace();
            };

           Console.WriteLine(count);
        }
    }
}

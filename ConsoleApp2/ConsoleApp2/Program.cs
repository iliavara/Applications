using System;

namespace ConsoleApp2
{
    class Program
    {
        public static int MinSplit(int amount)
        {
            int total = amount;
            int count = 0;

            int cash_1 = 1;
            int cash_5 = 5;
            int cash_10 = 10;
            int cash_20 = 20;
            int cash_50 = 50;

            while (total != 0)
            {
                if (total >= cash_50)
                {
                    total = total - cash_50;
                    count++;
                }
                else if (total >= cash_20)
                {
                    total = total - cash_20;
                    count++;
                }
                else if (total >= cash_10)
                {
                    total = total - cash_10;
                    count++;
                }
                else if (total >= cash_5)
                {
                    total = total - cash_5;
                    count++;
                }
                else
                {
                    total = total - cash_1;
                    count++;
                }
            }
            return count;
        }
        static void Main(string[] args)
        {
            int x;
            x = Convert.ToInt32(Console.ReadLine());
            int y;
            y = MinSplit(x);
            Console.WriteLine(y);
        }
    }
}

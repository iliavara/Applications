using System;

namespace ConsoleApp5
{
    class Program
    {
        public static int Fibonacci(int n)
        {
            if (n <= 1)
            {
                return n;
            }
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }


        public static int CountVariants(int stairsCount)
        {
            return Fibonacci(stairsCount + 1);
        }

        static public void Main()
        {
            int x;
            x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Number of ways = " + CountVariants(x));
        }
    }
}
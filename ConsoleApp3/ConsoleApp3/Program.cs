using System;
using System.Linq;

namespace ConsoleApp3
{
    class Program
    {
        public static int NotContains(int[] array)
        {
            if (array != null && array.Any())
            {
                Array.Sort(array);

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] > 0)
                    {
                        var prev = i > 0 ? array[i - 1] : 0;

                        if (prev < 0)
                        {
                            prev = 0;
                        }

                        if (array[i] - prev > 1)
                        {
                            return prev + 1;
                        }
                        else if (i == array.Length - 1)
                        {
                            return array[i] + 1;
                        }
                    }
                }
            }

            return 1;
        }
        static void Main(string[] args)
        {
            int[] massive = { -2, 0, 1, 2, 3, 5, 7, 17 };
            int x;
            x = NotContains(massive);
            Console.WriteLine(x);
        }
    }
}
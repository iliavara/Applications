using System;

namespace ConsoleApp4
{
    class Program
    {
        public static bool IsProperly(string sequence)
        {
            var counter = default(int);

            foreach (var c in sequence)
            {
                switch (c)
                {
                    case '(':
                        counter++;
                        break;
                    case ')':
                        counter--;
                        break;
                }

                if (counter < 0)
                {
                    return false;
                }
            }

            return counter == 0;
        }
        static void Main(string[] args)
        {
            string x;
            x = Console.ReadLine();
            if (IsProperly(x)) { Console.WriteLine("Yes"); }
            else Console.WriteLine("No");
        }
    }
}
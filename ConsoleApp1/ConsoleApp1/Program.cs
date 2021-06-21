using System;

namespace ConsoleApp1
{
    class Program
    {
        public static bool IsPalindrome(string text)
        {
            if (text?.Length > 0)
            {
                var i = 0;
                var j = text.Length - 1;

                while (j - i > 0)
                {
                    if (text[i++] != text[j--])
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }
        static void Main(string[] args)
        {
            string x;
            x = Console.ReadLine();
            if (IsPalindrome(x) == true)
            {
                Console.WriteLine("Is a Palindrome");
            }
            else Console.WriteLine("Is NOT a Palindrome");
        }
    }
}

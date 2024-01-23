using System.Data;
using System.Collections.Generic;

namespace ProjectEuler
{
    public static class Funcs
    {
        public static bool IsPalindrome(string word)
        {
            bool isPalindrome = true;
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] != word[word.Length - 1 - i]) isPalindrome = false;
            }
            return isPalindrome;
        }

        public static bool IsPrime(long p)
        {
            bool prime = true;
            for (int i = 2; i < p; i++)
            {
                if (p % i == 0)
                {
                    prime = false;
                    break;
                }
            }
            return prime;
        }

        public static int Divisors(long d)
        {
            // Find all primes and multiply sqrt(d)
            int divs = 2;
            for (double i = Math.Sqrt(d); i > 1; i--)
            {
                if (d % i == 0)
                {
                    divs++;
                }
            }
            return divs;
        }
    }
}
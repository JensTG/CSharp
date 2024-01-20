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

        public static long Triangular(long t)
        {
            return (long)(0.5 * (t * t) + 0.5 * t);
        }

        public static List<long> Divisors(long d)
        {
            List<long> divs = new List<long> { d };
            for (long i = d % 2 == 0 ? d / 2 : (d + 1) / 2; i > 0;)
            {
                if (d % i == 0)
                {
                    divs.Add(i);
                    i = i % 2 == 0 ? i / 2 : (i + 1) / 2;
                }
                else i--;
            }
            return divs;
        }
    }
}
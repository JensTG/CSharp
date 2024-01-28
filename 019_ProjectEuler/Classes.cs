using System.Data;
using System.Collections.Generic;
using System;
using static System.Console;
using static System.Math;
using static System.Int32;
using System.Security.Cryptography;

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
            int divs = 0;
            for (long i = 1; i <= Sqrt(d); i++)
            {
                if (d % i == 0)
                {
                    divs++;
                }
            }
            return divs * 2;
        }

        public static string Add(string s1, string s2)
        {
            int carry = 0;
            int diff = s1.Length - s2.Length;
            switch (diff)
            {
                case < 0:
                    for (int i = 0; i > diff; i--)
                    {
                        s1 = '0' + s1;
                    }
                    s2 = '0' + s2;
                    break;
                case > 0:
                    for (int i = 0; i < diff; i++)
                    {
                        s2 = '0' + s2;
                    }
                    s1 = '0' + s1;
                    break;
                case 0:
                    s2 = '0' + s2;
                    s1 = '0' + s1;
                    break;
            }
            string s3 = "";
            for (int i = s1.Length; i >= 0; i--)
            {
                int result = Parse(s1.Substring(i)) + Parse(s2.Substring(i)) + carry;
                carry = 0;
                if (result > 9)
                {
                    carry = 1;
                    result -= 10;
                }
                s3 = result.ToString() + s3;
            }
            return s3;
        }
    }
}
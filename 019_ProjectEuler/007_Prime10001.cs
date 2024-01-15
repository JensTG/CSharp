using System;

namespace ProjectEuler
{
    using static Funcs;
    using static System.Console;
    class Prime10001
    {
        static void Main()
        {
            int primes = 0;
            int i = 2;
            for (; primes < 10001; i++)
            {
                if (IsPrime(i)) primes++;
            }
            WriteLine("10001st prime: {0}", i - 1);
        }
    }
}
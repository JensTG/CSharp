namespace ProjectEuler
{
    using System.Collections.Generic;
    using static System.Console;
    class SummedPrimes
    {
        static void Main()
        {
            List<int> primes = new List<int> { 2 };
            long sum = 2;
            int i = 2;
            Start:
            for (; i < 2000000; i++)
            {
                foreach (int prime in primes)
                {
                    if (i % prime == 0)
                    {
                        i++;
                        goto Start;
                    }
                }
                sum += i;
                primes.Add(i);
            }
            WriteLine("Sum: {0}", sum);
        }
    }
}
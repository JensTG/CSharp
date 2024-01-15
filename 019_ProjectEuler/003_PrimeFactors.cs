using System;
using static ProjectEuler.Funcs;
using static System.Console;

namespace ProjectEuler
{
    class PrimeFactors
    {
        static void Main()
        {
            Write("Please input a number for factorization: ");
            long number = Int64.Parse(ReadLine());
            long largest = 0;
            WriteLine();

            while (!IsPrime(number))
            {
                for (int i = 2; true; i++)
                {
                    if (IsPrime(i) && number % i == 0)
                    {
                        number /= i;
                        largest = i > largest ? i : largest;
                        WriteLine("Factor: {0}", i);
                        break;
                    }
                }
            }
            WriteLine("Factor: {0}", number);
            largest = number > largest ? number : largest;
            WriteLine("\nLargest prime factor: {0}", largest);
        }
    }
}
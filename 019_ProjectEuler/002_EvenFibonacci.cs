using System;
namespace ProjectEuler
{
    class EvenFibonacci
    {
        static void Main()
        {
            int prev2 = 1;
            int prev = 2;
            int result = 0;
            int sum = 2;
            while (result < 4000000)
            {
                result = prev + prev2;
                if (result % 2 == 0) sum += result;
                prev2 = prev;
                prev = result;
            }
            Console.WriteLine("Sum: {0}", sum);
        }
    }
}
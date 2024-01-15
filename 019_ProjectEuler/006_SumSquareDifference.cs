using System;

namespace ProjectEuler
{
    using static System.Console;
    class SumSquareDifference
    {
        static void Main()
        {
            long summedSquares = 0;
            long squaredSum = 0;
            for(int i = 1; i <= 100; i++) {
                summedSquares += i * i;
                squaredSum += i;
            }
            squaredSum *= squaredSum;
            long diff = squaredSum - summedSquares;
            WriteLine("Difference: {0}", diff);
        }
    }
}
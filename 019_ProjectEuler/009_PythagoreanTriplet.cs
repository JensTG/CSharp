using System;

namespace ProjectEuler
{
    using static System.Console;
    class PythagoreanTriplet
    {
        static void Main()
        {
            // Brute forcing this:
            int a = 1;
            int b = 1;
            int c = 1;
            for (; true; c++)
                for (b = 1; b < c; b++)
                    for (a = 1; a < b; a++)
                    {
                        if (a + b + c != 1000) continue;
                        if (a * a + b * b != c * c) continue;
                        goto Solved;
                    }
            Solved:
            WriteLine("Solution: {0}", a * b * c);
        }
    }
}
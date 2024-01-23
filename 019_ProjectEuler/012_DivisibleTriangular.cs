using System;
using System.Collections.Generic;
using static System.Console;

namespace ProjectEuler
{
    using static Funcs;
    class DivisibleTriangular
    {
        static void Main()
        {
            Clear();
            int divs = 0;
            long n = 0;
            for (int i = 1; divs <= 500; i++)
            {
                n += i;
                divs = Divisors(n);
                WriteLine(divs);
            };
            WriteLine(">500 Divisors: {0}", n);
        }
    }
}
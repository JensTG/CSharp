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
            List<long> divs = Divisors(28);
            foreach(long l in divs) {
                WriteLine(l);
            }
        }
    }
}
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
            int i = 1;
            for(; divs <= 500; i++) {divs = Divisors((long)(0.5 * (i * i) + 0.5 * i));};
            WriteLine(">500 Divisors: {0}", i);
        }
    }
}
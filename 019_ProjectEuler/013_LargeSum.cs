using System;
using System.Collections.Generic;
using static System.Console;
using System.IO;

namespace ProjectEuler
{
    using static Funcs;
    class LargeSum
    {
        static void Main()
        {
            string[] nums = File.ReadAllLines(@"C:\VSC_PRO_B\CSharp\019_ProjectEuler\013_LargeSum.txt");
            WriteLine(Add("999", "999"));
        }
    }
}
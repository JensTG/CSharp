using System;

namespace ProjectEuler
{
    using static System.Console;
    class SmallestMultiple
    {
        static void Main()
        {
            int m = 20;
            for (; true; m++)
            {
                bool isMultiple = true;
                for (int i = 1; i <= 20; i++)
                {
                    if (m % i != 0)
                    {
                        isMultiple = false;
                        break;
                    }
                }
                if (isMultiple) break;
            }
            WriteLine("Smallest multiple: {0}", m);
        }
    }
}
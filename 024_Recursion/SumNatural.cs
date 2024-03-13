using System;
using static System.Console;
static class Program
{
    static void Main()
    {
        Write("Please input a number: ");
        int n = Int32.Parse(Console.ReadLine());
        WriteLine(SumNumbers(1, n));
    }
    static int SumNumbers(int start, int end)
    {
        if(start < end) return start + SumNumbers(start + 1, end);
        else return start;
    }
}
using System;
using static System.Console;

class Program
{
    static void Main()
    {
        Write("Please input a number: ");
        int n = Int32.Parse(Console.ReadLine());
        PrintNumbers(n);
    }
    static void PrintNumbers(int start)
    {
        Write(start + " ");
        if(start > 1) PrintNumbers(start - 1);
    }
}
using System;
using static System.Console;

class Program
{
    static void Main()
    {
        PrintNumbers(0, 10);
    }
    static void PrintNumbers(int start, int end)
    {
        Write(start + " ");
        if(start < end) PrintNumbers(start + 1, end);
    }
}
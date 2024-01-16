using System.Runtime.CompilerServices;
using static System.Console;

public static class Opgaver
{
    public static void SumEvenAndOdd()
    {
        int even = 0;
        int odd = 0;
        while (true)
        {
            try
            {
                int n = Int32.Parse(Console.ReadLine().Trim());
                switch (n % 2)
                {
                    case 0:
                        even += n;
                        break;
                    case 1:
                        odd += n;
                        break;
                }
                Console.Clear();
                Console.WriteLine("OddSum: {0}\nEvenSum: {1}", odd, even);
            }
            catch
            {
                break;
            }
        }
    }
    public static void HCF()
    {
        WriteLine("Please input 2 numbers:");
        int[] inputs = [int.Parse(ReadLine()), int.Parse(ReadLine())];
        int largest = 1;
        for (int i = 1; i <= Math.Min(inputs[0], inputs[1]); i++)
        {
            if (inputs[0] % i == 0 && inputs[1] % i == 0 && i > largest) largest = i;
        }
        WriteLine("Largest common factor: {0}", largest);
    }
    public static void Addition()
    {
        do
        {
            Clear();
            WriteLine("Please input 2 numbers:");
            int[] ins = { int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()) };
            Clear();
            WriteLine($"{ins[0]} + {ins[1]} = {ins[0] + ins[1]}\n");

            WriteLine("Would you like to quit? (Y/N)");
        } while (ReadKey().Key == ConsoleKey.Y);
    }
    public static void GuessGame()
    {
        int random = new Random().Next(100);
        while (true)
        {
            WriteLine("Take a guess:");
            int guess = int.Parse(ReadLine());
            Clear();
            if (guess == random)
            {
                WriteLine("You guessed it!");
                break;
            }
            else if (guess > random) WriteLine("Lower!");
            else if (guess < random) WriteLine("Higher!");
        }
    }
    public static void Collatz()
    {
        int n = int.Parse(ReadLine());
        Clear();
        Write(n.ToString().PadRight(6));
        for (int i = 0; i < n && i < WindowWidth; i++)
        {
            Write('█');
        }
        WriteLine();
        int steps = 0;
        while (n != 1)
        {
            if (n % 2 == 0) n /= 2;
            else n = n * 3 + 1;
            Write(n.ToString().PadRight(6));
            for (int i = 0; i < n && i < WindowWidth; i++)
            {
                Write('█');
            }
            WriteLine();
            steps++;
        }
        WriteLine("\nSteps taken: {0}", steps);
    }
    public static void PascalTriangle()
    {
        WriteLine("Please input the number of rows:");
        int rows = int.Parse(Console.ReadLine());
        Clear();
        int r = 1;
        WriteLine("1");
        while(r <= rows) {
            int c = 1;
            int n = 1;
            while(c <= r) {
                Write(n + " ");
                n = n * (r + 1 - c) / c;
                c++;
            }
            WriteLine("1");
            r++;
        }
    }
}
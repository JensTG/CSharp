namespace ProjectEuler
{
    class Multiples
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.ResetColor();
            Console.WriteLine("Please input a number above 0:");
            int limit = Int32.Parse(Console.ReadLine());

            int sum = 0;
            for (int i = 1; i < limit; i++)
            {
                if (i % 3 == 0 || i % 5 == 0) { sum += i; Console.WriteLine(i); }
            }
            Console.WriteLine("\nSum: {0}", sum);
        }
    }
}
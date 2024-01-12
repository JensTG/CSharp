class MultipleAsync
{
    static async Task Main()
    {
        List<int> primes = new List<int>();
        List<Task<List<int>>> tasks = new List<Task<List<int>>>();
        int n = 200000;

        for (int i = 0; i < 5; i++)
        {
            tasks.Add(CalculatePrimesInRange(i * n + 1, i * n + n));
        }
        foreach (Task<List<int>> task in tasks)
        {
            primes.AddRange(await task);
        }
        Console.WriteLine(primes);
    }

    static async Task<List<int>> CalculatePrimesInRange(int min, int max)
    {
        List<int> primes = new List<int>();
        bool isPrime;

        for (int i = min; i < max; i++)
        {
            isPrime = true;
            for (int j = 2; j < i; j++)
            {
                if (i % j == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            if (isPrime) Console.Write(i + " ");
        }
        return primes;
    }
}
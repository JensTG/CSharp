List<int> primes = new List<int>();
List<Task<List<int>>> calcs = new List<Task<List<int>>>();

for (int i = 5; i <= 10; i++)
{
    calcs.Add(CalculatePrimesInRange((i - 1) * 100, i * 100));
}
foreach (Task<List<int>> calc in calcs)
{
    primes.AddRange(await calc);
}
Console.Clear();
foreach (int prime in primes)
{
    Console.Write(prime);
}

async Task<List<int>> CalculatePrimesInRange(int min, int max)
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
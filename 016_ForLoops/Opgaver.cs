using System.Data;

public static class Opgaver
{
    public static void Første10()
    {
        for (int i = 1; i <= 10; i++) Console.WriteLine(i + " ");
    }
    public static void Sum10()
    {
        int sum = 0;
        for (int i = 1; i <= 10; i++) sum += i;
        Console.WriteLine(sum);
    }
    public static void SumN()
    {
        int limit = Int32.Parse(Console.ReadLine());
        int sum = 0;
        for (int i = 1; i <= limit; i++) sum += i;
        Console.WriteLine(sum);
    }
    public static void Read10()
    {
        Console.WriteLine("Please input 10 numbers:");
        int sum = 0;
        for (int i = 0; i < 10; i++) sum += Int32.Parse(Console.ReadLine());
        Console.WriteLine($"Sum: {sum} and Average: {sum / 10}");
    }
    public static void CubeN() {
        Console.WriteLine("Please input a limit:");
        int limit = Int32.Parse(Console.ReadLine());
        for (int i = 1; i <= limit; i++) Console.WriteLine($"The cube of {i} is {i*i*i}");
    }
    public static void MultiTable() {
        Console.WriteLine("Please input a number:");
        int n = Int32.Parse(Console.ReadLine());
        for(int i = 1; i <= 10; i++) Console.WriteLine($"{n} * {i} = {n*i}");
    }
    public static void WeirdMultiTable(){

    }
    public static void OddN() {
        int count = 0;
        int sum = 0;
        Console.WriteLine("Please input a limit:");
        int limit = Int32.Parse(Console.ReadLine());
        for(int i = 0; count < limit ;i++) {
            if(i % 2 == 1) {
                count++;
                Console.Write(i + " ");
                sum += i;
            }
        }
        Console.WriteLine("\nSum: {0}", sum);
    }
    public static void TriSlash() {
        
    }
}
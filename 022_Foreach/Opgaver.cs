using static System.Console;

public static class Opgaver
{
    public static void XVL()
    {
        Clear();
        List<int> nums = new List<int> {
            -10, -11, -12, -13, -14, 15, 16, 17, 18, 19, 20
        };
        int low = 0;
        int lower = 0;
        foreach (int num in nums)
        {
            if (num < lower)
            {
                low = lower;
                lower = num;
                continue;
            }
            low = num < low ? num : low;
        }
        if (low == 0 || lower == 0)
        {
            WriteLine("Not enough negative numbers");
            return;
        }
        WriteLine("Sum of lowest numbers: {0}", low + lower);
    }
    public static void XVIL() {
        Clear();
        WriteLine("Please input a sequence of numbers");
        string[] inputs = Console.ReadLine()!.Split(" ");
        List<int> nums = new List<int> ();
        foreach(string input in inputs) {
            nums.Add(int.Parse(input.Trim()));
        }
        int prev = nums.Min();
        bool cons = true;
        for(int i = 0; i  < nums.Count - 1; i++) {
            if(!nums.Contains(prev + 1)) {
                cons = false;
                break;
            }
            prev++;
        }
        WriteLine("The sequence is{0}consecutive", cons ? " " : " not ");
    }
    public static void XVIIL() {

    }
    public static void XIIXL() {

    }
    public static void XIXL() {

    }
    public static void XL() {
        Clear();
        WriteLine("Please input a sequence of numbers");
        string input = Console.ReadLine()!;
        string[] inputs = input.Contains(',') ? input.Split(',') : input.Split(" ");
        List<int> nums = new List<int> ();
        foreach(string part in inputs) {
            nums.Add(int.Parse(part.Trim()));
        }
        int small = 1;
        while(nums.Contains(small)) small++;
        WriteLine("Smallest positive integer not included in the sequence: {0}", small);
    }
}
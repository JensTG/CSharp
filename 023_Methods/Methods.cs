using static System.Console;
public static class MethodOpgaver
{
    public static void Greet()
    {
        WriteLine("Welcome Friends!\nHave a nice day!");
    }
    public static void GreetName(string name)
    {
        WriteLine("Welcome Friend {0}!\nHave a nice day!", name);
    }
    public static int AddNums(int a, int b)
    {
        return a + b;
    }
    public static int CountSpaces(string text)
    {
        int spaces = 0;
        foreach(char c in text)
        {
            if(c == ' ') spaces++;
        }
        return spaces;
    }
    public static int SumArray(int[] values)
    {
        int sum = 0;
        foreach(int value in values) sum += value;
        return sum;
    }
    public static int[] SwapNums(int[] ints)
    {
        return ints.Reverse().ToArray();
    }
    public static float RaiseNum(int baseNum, int exponent)
    {
        float res = 1.0f;
        if(exponent == 0) return res;
        else
        {
            for(int i = 0; i < Math.Abs(exponent); i++) res *= baseNum;
        }
        res = exponent < 0 ? 1 / res : res;
        return res;
    }
    public static void DisplayFib(int length)
    {
        int prev2 = 0;
        int prev = 1;
        int result = 0;
        Write("{0} {1} ", prev2, prev);
        for(int i = 0; i < length - 2; i++)
        {
            result = prev + prev2;
            prev2 = prev;
            prev = result;
            Write(result + " ");
        }
    }
    public static bool IsPrime(long p)
    {
        bool prime = true;
        for (int i = 2; i < p; i++)
        {
            if (p % i == 0)
            {
                prime = false;
                break;
            }
        }
        return prime;
    }
    public static int Tværsum(int a)
    {
        int sum = 0;
        string num = a.ToString();
        foreach(char c in num) sum += Convert.ToInt32(c) - 48;
        return sum;
    }
}
using static System.Console;
using static MethodOpgaver;

Start:
Clear();
Write("Please select an assignment: ");
int n = int.Parse(ReadLine()!);
Clear();
switch (n)
{
    case 1:
        Greet();
        break;
    case 3 or 5 or 6 or 7:
        int[] inputs = new int[n == 5 ? 5 : 2];
        for (int i = 0; i < inputs.Length; i++)
        {
            WriteLine("Please input {0} numbers:", inputs.Length);
            inputs[i] = int.Parse(Console.ReadLine()!);
            Clear();
        }
        switch (n)
        {
            case 3:
                WriteLine("The sum is: " + AddNums(inputs[0], inputs[1]));
                break;
            case 5:
                WriteLine("The sum is: " + SumArray(inputs));
                break;
            case 6:
                int[] swapped = SwapNums(inputs);
                WriteLine("The swapped numbers look like this: ");
                foreach(int num in swapped) Write(num + " ");
                break;
            case 7:
                WriteLine(RaiseNum(inputs[0], inputs[1]));
                break;
        }
        break;
    case 2 or 4:
        WriteLine("Please input a string: ");
        string input = Console.ReadLine()!;
        Clear();
        if(n == 2) GreetName(input);
        else WriteLine("There are {0} spaces", CountSpaces(input));
        break;
    case 8 or 9 or 10:
        Write("Please input a number: ");
        int intput = int.Parse(Console.ReadLine()!);
        Clear();
        switch(n)
        {
            case 8:
                WriteLine("Fibbonaci ({0} numbers): ", intput);
                DisplayFib(intput);
                break;
            case 9:
                WriteLine("{0} is {1}", intput, IsPrime(intput) ? "prime" : "not prime");
                break;
            case 10:
                WriteLine("Tværsummen af {0} er {1}", intput, Tværsum(intput));
                break;
        }
    break;
    default:
        goto Start;
}
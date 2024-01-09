Console.Clear();
Console.ForegroundColor = ConsoleColor.Yellow;

Console.WriteLine("Please enter a limit for your mysterious search:");
Console.ResetColor();

bool mysterious;
int mysteriousLimit = Int32.Parse(Console.ReadLine());

Console.Clear();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine($"These are all the mysterious numbers between 1 and {mysteriousLimit}:");
Console.ResetColor();

for (int i = 1; i < mysteriousLimit; i++)
{
    mysterious = true;
    for (int j = 2; j < i; j++)
    {
        if (i % j == 0)
        {
            mysterious = false;
            break;
        }
    }
    if(mysterious) Console.Write(i + " ");
}

Console.CursorVisible = false;
Console.ReadKey();
Console.CursorVisible = false;
Console.Clear();
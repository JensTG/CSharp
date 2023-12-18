Console.Clear();
Console.WriteLine("Please input a number:");
int input = Int32.Parse(Console.ReadLine());
if(input < 0) Console.WriteLine($"{input} is negative");
else if(input > 0) Console.WriteLine($"{input} is positive");
else Console.WriteLine($"{input} is neither");
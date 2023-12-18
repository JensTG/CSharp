Console.Clear();
Console.WriteLine("Please input a year:");
int input = Int32.Parse(Console.ReadLine());
int remainder = input % 4;
if(remainder == 0) Console.WriteLine($"{input} is a leap year");
else Console.WriteLine($"{input} is not a leap year");
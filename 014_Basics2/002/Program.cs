Console.WriteLine("Please input a number:");
int input = Int32.Parse(Console.ReadLine());
int remainder = input % 2;
if(remainder == 0) Console.WriteLine($"{input} is even");
else Console.WriteLine($"{input} is odd");
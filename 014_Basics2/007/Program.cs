Console.WriteLine("Please input your height (in cm):");
int height = Int32.Parse(Console.ReadLine());

if(height<140) Console.WriteLine("You are very small!");
else if(height >200) Console.WriteLine("You are very big!");
else Console.WriteLine("You are very!");
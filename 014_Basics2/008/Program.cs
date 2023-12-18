int[] inputs = new int[3];
for (int i = 0; i < 3; i++)
{
    inputs[i] = Int32.Parse(Console.ReadLine());
}
int n = 0;
foreach (int input in inputs)
{
    if (input > n) n = input;
}
Console.WriteLine("Largest number: {0}", n);
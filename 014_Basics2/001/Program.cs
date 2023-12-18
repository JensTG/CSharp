List<int> inputs = new List<int> ();
Console.WriteLine("Please input some numbers:");
for(int i = 0; i < 2; i++) {
    inputs.Add(Int32.Parse(Console.ReadLine()));
}
if(inputs[0] == inputs[1]) Console.WriteLine($"{inputs[0]} and {inputs[1]} are equal");
else Console.WriteLine($"{inputs[0]} and {inputs[1]} are not equal");
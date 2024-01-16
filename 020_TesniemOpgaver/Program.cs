using static Opgaver;
List<Action> opgaver = new List<Action> {
    SumEvenAndOdd,
    HCF,
    Addition,
    GuessGame,
    Collatz,
    PascalTriangle
};
Console.Clear();
Console.WriteLine("Which solution would you like to see?");
int opgN = Int32.Parse(Console.ReadLine());
Console.Clear();
opgaver[opgN - 1]();
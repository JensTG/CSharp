int opgNr = Int32.Parse(Console.ReadLine());
Console.Clear();
List<Action> opgaver = new List<Action> {
    Opgaver.Første10, 
    Opgaver.Sum10,
    Opgaver.SumN,
    Opgaver.Read10,
    Opgaver.CubeN,
    Opgaver.MultiTable,
    Opgaver.WeirdMultiTable,
    Opgaver.OddN,
    Opgaver.TriSlash
};
opgaver[opgNr - 1]();
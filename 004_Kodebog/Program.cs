int counter = 0;
int length = display(0);

while(true){
Console.WriteLine(counter);
ConsoleKeyInfo keyInfo = Console.ReadKey(true);
string key = keyInfo.Key.ToString();
switch(key) {
    case "W": counter = 0; break;
    case "A": counter--; break;
    case "D": counter++; break;
}
display(counter);

}


int display(int kap) {
    Dictionary<string, List<string>> bog = new Dictionary<string, List<string>>();
    bog.Add("forside", new List<string> {
        "       Kapitler",
        "",
        "",
        "Variabler              1",
        "If, else og switch     2",
        "Operatorer             3",
        "Loops                  4"
    });
    return bog.Count;
}
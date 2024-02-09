using static Opgaver;
using static System.Console;
List<Action> opgaver = new List<Action>
{
    XVL,
    XVIL,
    XVIIL,
    XIIXL,
    XIXL,
    XL
};

NoSuccess:
Clear();
WriteLine("Please input an assignment:");
bool success = Int32.TryParse(Console.ReadLine(), out int n);
if(!success) goto NoSuccess;
try {opgaver[n - 35]();}
catch {goto NoSuccess;}
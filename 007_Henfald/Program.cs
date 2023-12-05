using PData;

// Variable:
int A; // Massetal
int Z; // Protoner
int N; // Neutroner

bool done = false;

List<Grundstof> grundstoffer = new List<Grundstof> ();

for(int i = 0; i < D.henfald.Count; i++) {
    grundstoffer.Add(new Grundstof(D.henfald.Keys.ElementAt(i), D.henfald.Values.ElementAt(i)));
}

// Selve programmet:
while(true) {
Console.Clear();
Console.WriteLine("Indtast en radioaktiv isotop (eller q for at afslutte):");
string stringIn = Console.ReadLine();
if(stringIn.ToLower() == "q") break;
string[] splitStringIn = stringIn.Split('-');
for(int i = 0; true; i++) {
    if(D.henfald.Keys.ElementAt(i) == splitStringIn[0]) {Z = i; break;}
}
N = Int32.Parse(splitStringIn[1]) - Z;

List<int> kerne = new List<int> (16) {Z, N};

do {
    done = true;
    Console.Write("-> ");
    for(int i = 0; i < kerne.Count; i += 2){
        if(D.henfald.Values.ElementAt(kerne[i]).ElementAt(kerne[i+1]) != "S") {
            List<int> nyKerne = grundstoffer[kerne[i]].NyKerne(kerne[i + 1]);
            kerne.RemoveRange(i, 2);
            kerne.InsertRange(i, nyKerne);
            Console.Write($"{D.henfald.Keys.ElementAt(kerne[i])}-{kerne[i+1]+kerne[i]}      ");
        }
    }
    for(int i = 0; i < kerne.Count; i += 2){
        if(D.henfald.Values.ElementAt(kerne[i]).ElementAt(kerne[i+1]) != "S") {
            done = false;
        }
    }
    Console.WriteLine();
} while (!done);
Console.ReadKey();
}
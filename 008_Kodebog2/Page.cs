using System.Diagnostics;

public class Page
{
    public string Content;
    public Page(string content)
    {
        Content = content;
    }

    public void Read(string chapTitle)
    {
        // En fin overskrift, som passer til kapitlet:
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"{chapTitle}\n");

        if (!Content.Contains("KODE")) {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(Content);
            return;
        }
        // Split tekstfilen i kodeblokke og tekst
        string[] strArr = Content.Split("KODE");
        for(int i = 0; i< strArr.Length; i++) {

            // Farv hver anden blok grøn/grå, for at indikere kode:
            if (i % 2 == 0) {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(strArr[i]);
            } else {
                string[] strArr2 = strArr[i].Split("\n");

                // Find den længste string i strArr2:
                int maks = strArr2.OrderByDescending(s => s.Length).First().Length;

                for(int j = 1; j < strArr2.Length - 1; j++) {
                    Console.ResetColor();
                    if(strArr2[j].Contains("//")) {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    } else {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    if (j != 1) Console.WriteLine();
                    Console.Write("\x1b[48;5;236m" + strArr2[j].PadRight(maks).Replace("\r", ""));
                }
            }
        }
        Console.WriteLine();
        Console.ResetColor();
    }

    public void ReadArr(string chapTitle) {
        
    }
}
using System.IO.Compression;
using System.Xml;

FileStream zipArchive = new FileStream(@"C:\Users\jens\Downloads\Mappe1.xlsx", FileMode.OpenOrCreate);
ZipArchive archive = new ZipArchive(zipArchive, ZipArchiveMode.Update);

string message = "";
List<string> IDs = new List<string>();
List<string> names = new List<string>();

foreach (ZipArchiveEntry entry in archive.Entries)
{
    StreamReader sr = new StreamReader(entry.Open());
    XmlReader xr = XmlReader.Create(sr);
    if (entry.FullName.Contains("workbook"))
    {
        while (xr.Read())
        {
            if (xr.Name == "sheet")
            {
                names.Add(xr.GetAttribute("name"));
                IDs.Add("sheet" + xr.GetAttribute("sheetId"));

                Console.WriteLine(names.Last() + " corresponds to " + IDs.Last());
            }
        }
        break;
    }
}

List<string> options = new List<string>();
int n = 0;      // Will keep track of the selected option
int prevN = 0;  // And will be used to erase highlights
Console.CursorVisible = false;

// Write options to the console:
Console.Clear();
Console.SetCursorPosition(1, 0);
Console.WriteLine(message + "\n");
foreach (string option in options)
{
    Console.WriteLine(option);
    Thread.Sleep(4);
}

while (true)
{
    Highlight(prevN + 2, options[prevN], ConsoleColor.Black, ConsoleColor.White);
    Highlight(n + 2, options[n]);

    // Get user input:
    ConsoleKey input = Console.ReadKey().Key;
    prevN = n;
    switch (input)
    {
        case ConsoleKey.UpArrow: if (n > 0) n--; break;
        case ConsoleKey.DownArrow: if (n < options.Count - 1) n++; break;
        case ConsoleKey.LeftArrow: n = 0; break;
        case ConsoleKey.RightArrow: n = options.Count - 1; break;

        case ConsoleKey.Enter:
            string sheetID = options[n];
            Console.CursorVisible = true;
            Console.WriteLine("You have chosen: {0}", sheetID);
            break;
    }
}
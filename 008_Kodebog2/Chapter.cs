public class Chapter
{
    public string Title;
    public List<Page> Pages;
    public Chapter(string title)
    {
        Title = title;
        Pages = new List<Page>();
    }

    public Chapter(string title, List<Page> pages)
    {
        Title = title;
        Pages = pages;
    }

    public void Read()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(Title);
        Console.ResetColor();
        foreach (Page page in Pages)
        {
            Console.Clear();
            page.Read(Title);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    public void AddPage(string title)
    {
        List<string> Lines = new List<string> {};
        string content;
        while(true) {
            content = "";
            foreach(string line in Lines) {
                content += line + "\n";
            }
            Page temp = new Page(content);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(
                "Slet sidste linje med           \"DEL\"\n" +
                "Start/slut en kodeblok med      \"k\" el. \"KODE\"\n" +
                "Gem teksten som en fil med      \"QUIT\"\n");
            temp.Read(Title + ":");
            string input = Console.ReadLine();
            if(input == "QUIT") break;
            switch(input) {
                case "DEL":
                if(Lines.Last() == "KODE")
                Lines.RemoveAt(Lines.Count - 1);
                Lines.RemoveAt(Lines.Count - 1);
                break;
                case "k":
                Lines.Add("KODE");
                break;
                default:
                Lines.Add(input);
                break;
            }
        }
        Pages.Add(new Page(content));
        File.WriteAllText($"Notes\\{Title}\\{title}.txt", content);
    }
}
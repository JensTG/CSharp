public class Book
{
    public string Title;
    public List<Chapter> Chapters;
    public Book(string title = "Programming notes")
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Title = title;
        Chapters = new List<Chapter>();
    }

    public Book(string title, List<Chapter> chapters)
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Title = title;
        Chapters = chapters;
    }

    public void PrintChapters()
    {
        //Print chapter titles
        Console.ForegroundColor = ConsoleColor.Yellow;
        foreach (Chapter chapter in Chapters)
        {
            Console.WriteLine(chapter.Title);
        }
        Console.ResetColor();
    }

    private Chapter GetChapter(string title)
    {
        foreach (Chapter chapter in Chapters)
        {
            if (chapter.Title.ToLower() == title)
            {
                return chapter;
            }
        }
        return null;
    }

    public void Start()
    {
        while (true)
        {
            //Print book title and introduction
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Title);
            Console.ResetColor();
            Console.Clear();

            Console.WriteLine("\nDette er vores forsøg på en bog med noter fra undervisningen.\n" +
                "Fremover vil vi kunne konsultere denne bog, når vi leder\n" +
                "efter den bedste løsning på et problem i vores kode.\n");

            //Print chapter titles
            Console.WriteLine("Kapitler:");
            PrintChapters();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nEnter a chapter title to read it, \nC to create a new chapter or page, \nor 'quit/q/exit' to exit: \n");
            Console.ResetColor();
            string input = Console.ReadLine().ToLower();
            if (input == "quit" || input == "q" || input == "exit")
            {
                break;
            } 
            else if(input == "c") 
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Eksisterende kapitler:");
                PrintChapters();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\nInput an existing chapter to add a page to it\nor create a new one by typing in a different title:\n");
                Console.ResetColor();
                string chapterInput = Console.ReadLine().ToLower();
                if(GetChapter(chapterInput) != null) {
                    Chapter chapterToWrite = GetChapter(chapterInput);
                    Console.Clear();
                    
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Eksisterende sider i {chapterToWrite.Title}:");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    string[] files = Directory.GetFiles($"Notes\\{chapterToWrite.Title}");
                    foreach(string file in files)
                    {
                        Console.WriteLine(file.Substring(7 + chapterToWrite.Title.Length, file.Length - (11 + chapterToWrite.Title.Length)));
                    }
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"\nPlease input a fitting title for your new page:\n");
                    Console.ResetColor();
                    string newPageTitle = Console.ReadLine();
                    chapterToWrite.AddPage(newPageTitle);
                } else {
                    Chapters.Add(new Chapter(chapterInput));
                }
                continue;
            } 
            else 
            {
                Chapter chapterToRead = GetChapter(input);
                if (chapterToRead == null)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Chapter not found.\n");
                    Console.ResetColor();
                    continue;
                }
                chapterToRead.Read();
            }
        }
    }
}
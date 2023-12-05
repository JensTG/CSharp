List<Chapter> chapters = new List<Chapter>();

string[] dirs = Directory.GetDirectories("Notes");
foreach(string dir in dirs)
{
    string[] files = Directory.GetFiles(dir);
    List<Page> pages = new List<Page>();
    foreach(string file in files)
    {
        string content = File.ReadAllText(file);
        pages.Add(new Page(content));
    }
    string title = Path.GetFileName(dir);
    chapters.Add(new Chapter(title, pages));
}

Book book = new Book("Kodebogen 2.0", chapters);

book.Start();
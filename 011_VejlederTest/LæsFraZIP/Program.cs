using System;
using System.IO;
using System.IO.Compression;
using System.Net.Mime;
using System.Xml;

string zipPath = @"C:\Users\jens\Downloads\Mappe1.xlsx";
string sheetID = "sheet2";

FileStream zipArchive = new FileStream(zipPath, FileMode.OpenOrCreate);
ZipArchive archive = new ZipArchive(zipArchive, ZipArchiveMode.Update);

List<int> raw = new List<int>();
List<bool> isText = new List<bool>();
List<string> sharedStrings = new List<string>();

foreach (ZipArchiveEntry entry in archive.Entries)
{
    StreamReader sr = new StreamReader(entry.Open());
    XmlReader xr = XmlReader.Create(sr);
    if (entry.FullName.Contains(sheetID))
    {
        while (xr.Read())
        {
            string val = xr.Value;
            int res;
            if (Int32.TryParse(val, out res))
            {
                raw.Add(res);
                if (xr.GetAttribute("t") != null) isText.Add(true);
                else isText.Add(false);
            }
        }
    }
    else if (entry.FullName.Contains("sharedStrings"))
    {
        xr.MoveToContent();
        while (xr.Read())
        {
            string val = xr.Value;
            if (val != string.Empty) sharedStrings.Add(val);
        }
    }
    xr.Close();
    sr.Close();
}



for (int i = 0; i < raw.Count; i++)
{
    int col = i % 3;
    switch (col)
    {
        // The first name:
        case 0:
            
            break;

        // The second name:
        case 1:
            break;

        // The amount of meetings:
        case 2:
            break;
    }
}

// using (FileStream zipToOpen = new FileStream(@"C:\Users\jens\Downloads\Mappe1.xlsx", FileMode.Open))
// {
//     using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
//     {
//         ZipArchiveEntry readmeEntry = archive.CreateEntry("Readme.txt");
//         using (StreamWriter writer = new StreamWriter(readmeEntry.Open()))
//         {
//                 writer.WriteLine("Information about this package.");
//                 writer.WriteLine("========================");
//         }
//     }
// }
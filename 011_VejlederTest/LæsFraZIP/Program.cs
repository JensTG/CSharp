using System;
using System.IO;
using System.IO.Compression;
using System.Xml;

string zipPath = @"C:\Users\jens\Downloads\Mappe1.xlsx";

FileStream zipArchive = new FileStream(zipPath, FileMode.OpenOrCreate);
ZipArchive archive = new ZipArchive(zipArchive, ZipArchiveMode.Update);

List<string> sharedStrings = new List<string> ();

foreach(ZipArchiveEntry entry in archive.Entries) {
    StreamReader sr = new StreamReader(entry.Open());
    XmlReader xr = XmlReader.Create(sr);
    if(entry.FullName.Contains("sheet2")) {
        while(xr.Read()) {
            if(xr.Name.ToString() == "v") {
                Console.WriteLine(xr.ReadElementContentAsString());
            }
        }
    } else if (entry.FullName.Contains("sharedStrings")) {
        do {
            if(xr.Name.ToString() == "t") {
                sharedStrings.Add(xr.ReadElementContentAsString());
                Console.WriteLine(xr.ReadElementContentAsString());
            }
        } while(xr.Read());
    }
    xr.Close();
    sr.Close();
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
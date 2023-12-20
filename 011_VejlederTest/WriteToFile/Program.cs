using System.Xml;
using System.IO.Compression;
using System;
using System.IO;
using System.Net.Mime;

FileStream zipToOpen = new FileStream(@"C:\Users\jens\Downloads\Mappe1.xlsx", FileMode.Open);
ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update);

ZipArchiveEntry readmeEntry = archive.CreateEntry("Readme.txt");
using (StreamWriter writer = new StreamWriter(readmeEntry.Open()))
{
    writer.WriteLine("Information about this package.");
    writer.WriteLine("========================");
}
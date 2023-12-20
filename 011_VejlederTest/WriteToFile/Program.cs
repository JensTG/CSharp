using System;
using System.IO;
using System.IO.Compression;
using System.Xml;

using (FileStream zipToOpen = new FileStream(@"c:\Users\jens\Downloads\Mappe1.xlsx", FileMode.Open))
{
    using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
    {
        foreach (ZipArchiveEntry entry in archive.Entries)
        {
            if (entry.Name.Contains("workbook"))
            {
                StreamReader sr = new StreamReader(entry.Open());
                XmlReader xr = XmlReader.Create(sr);
                XmlDocument doc
                xr.Close();
                sr.Close();

                StreamWriter sw = new StreamWriter(entry.Open());
                XmlWriter xw = XmlWriter.Create(sw);

                xw.Close();
                sw.Close();
            }
        }

    }
}
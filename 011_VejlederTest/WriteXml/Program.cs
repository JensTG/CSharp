using System.IO.Compression;
using System.Text;
using System.Text.Encodings.Web;
using System.Xml;
using XmlTest;

FileStream zipArchive = new FileStream(@"C:\VSC_PRO_B\CSharp\011_VejlederTest\WriteXml\Test.xlsx", FileMode.OpenOrCreate);
ZipArchive archive = new ZipArchive(zipArchive, ZipArchiveMode.Update);

// Workbook
List<string> sheets = new List<string>();
string workContent = string.Empty;
string resultName = "Resultat" + DateTime.Now.Ticks;
ZipArchiveEntry workbook = archive.GetEntry("xl/workbook.xml");

foreach (ZipArchiveEntry entry in archive.Entries)
{
    if (entry.FullName.Contains("sheet")) sheets.Add("sheet" + (sheets.Count + 1).ToString());
}

using (StreamReader sr = new StreamReader(workbook.Open())) workContent = sr.ReadToEnd();
List<string> nodes = workContent.Split('>').ToList();
workContent = string.Empty;
foreach (string node in nodes)
{
    workContent += node + '>';
    if (nodes.IndexOf(node) != nodes.Count - 1 && node.Contains("sheet") && nodes[nodes.IndexOf(node) + 1].Contains("sheets"))
    {
        workContent += $"<sheet name=\"{resultName}\" sheetId=\"{sheets.Count + 1}\" r:id=\"rId{sheets.Count + 1}\"/>";
    }
}
workContent = workContent.Remove(workContent.Length - 1);

// SharedStrings
List<string> sharedStrs = new List<string>();
string xmlns = "http://schemas.openxmlformats.org/spreadsheetml/2006/main";
int count = 0;
int uniqueCount = 0;
string sharedContent = string.Empty;
ZipArchiveEntry sharedStrings = archive.GetEntry("xl/sharedStrings.xml");

using (StreamReader sr = new StreamReader(sharedStrings.Open())) sharedContent = sr.ReadToEnd();
using (StringReader tr = new StringReader(sharedContent))
using (XmlReader xr = XmlReader.Create(tr))
{
    bool first = true;
    while (xr.Read())
    {
        if (xr.Name == "sst" && first)
        {
            xmlns = xr.GetAttribute("xmlns");
            count = Int32.Parse(xr.GetAttribute("count"));
            uniqueCount = Int32.Parse(xr.GetAttribute("uniqueCount"));
            first = false;
        }
        else if (xr.Name == "t")
        {
            sharedStrs.Add(xr.ReadElementContentAsString());
            Console.WriteLine(sharedStrs.Last());
        }
    }
}

// Construct sheet:
ZipArchiveEntry sheet = archive.CreateEntry($"xl/worksheets/sheet{sheets.Count() + 1}.xml");
List<List<string>> plan = new List<List<string>> { new List<string> { "4", "2", "4" }, new List<string> { "4", "2", "4" }, new List<string> { "4", "2", "4" }, new List<string> { "4", "2", "4" } };
List<string> cells = new List<string>();
string sheetData = "";
char[] alpha = { 'A', 'B', 'C', 'D', 'E' };
int rowN = 0;
foreach (List<string> row in plan)
{
    rowN++;
    cells.Clear();
    Dictionary<string, string> rowAtts = new Dictionary<string, string> { { "r", rowN.ToString() }, { "spans", $"1:{row.Count}" }, { "x14ac:dyDescent", "0.25" } };
    int cN = 0;
    foreach (string s in row)
    {
        string value = "";
        Dictionary<string, string> cellAtts = new Dictionary<string, string> { { "r", alpha[cN] + rowAtts["r"] } };
        if (Int32.TryParse(s, out int n))
        {
            value = s;
        }
        else
        {
            cellAtts.Add("t", "s");
            if (sharedStrs.Contains(s)) value = sharedStrs.IndexOf(s).ToString();
            else
            {
                sharedStrs.Add(s);
                value = (sharedStrs.Count - 1).ToString();
                uniqueCount++;
            }
            count++;
        }
        cells.Add(XmlFuncs.XmlString("c", cellAtts, XmlFuncs.XmlString("v", value)));
        cN++;
    }
    sheetData += XmlFuncs.XmlString("row", rowAtts, cells);
}
sheetData = XmlFuncs.XmlString("sheetData", sheetData);
sheetData = File.ReadAllText(Path.GetFullPath("SheetTemplate.txt")).Replace("SHEETDATA", sheetData).Replace("SIZE", $"A1:{plan[0].Count}{plan.Count()}");

// Overwrite:
using (StreamWriter sw = new StreamWriter(workbook.Open()))
    foreach (char letter in workContent)
        sw.Write(letter);

using (StreamWriter sw = new StreamWriter(sheet.Open()))
    foreach (char letter in sheetData)
        sw.Write(letter);

// Ændr .rels filen så id'ene matcher
// Ændr [Content-types].xml så det nye ark indgår i den

archive.Dispose();
zipArchive.Dispose();
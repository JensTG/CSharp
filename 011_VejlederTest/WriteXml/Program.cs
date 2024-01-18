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
ZipArchiveEntry workbook = archive.GetEntry("xl/workbook.xml")!;

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

// Establish shared strings:
List<string> sharedStrs = new List<string>();
string xmlns = "http://schemas.openxmlformats.org/spreadsheetml/2006/main";
int count = 0;
int uniqueCount = 0;
string sharedContent = string.Empty;
ZipArchiveEntry sharedStrings = archive.GetEntry("xl/sharedStrings.xml")!;

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
sheetData = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" + sheetData;

// workbook.xml.rels:
ZipArchiveEntry rels = archive.GetEntry(@"xl\_rels\workbook.xml.rels")!;
string relsContent;
using (StreamReader sr = new StreamReader(rels.Open())) relsContent = sr.ReadToEnd();
string[] relIDs = relsContent.Split('>');
List<string> relSheets = new List<string>();
foreach (string node in relIDs)
{
    if (node.Contains("http://schemas.openxmlformats.org/officeDocument/2006/relationships/worksheet")) relSheets.Add(node + '>');
}
relSheets.Add("<Relationship Id=\"rId\"" + (sheets.Count + 1) + "\" Type=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships/worksheet\" Target=\"worksheets/sheet" + (sheets.Count + 1) + ".xml\"/>");
relSheets.Add("<Relationship Id=\"rId3\" Type=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships/theme\" Target=\"theme/theme1.xml\"/>" +
    "<Relationship Id=\"rId5\" Type=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships/sharedStrings\" Target=\"sharedStrings.xml\"/>" +
    "<Relationship Id=\"rId4\" Type=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships/styles\" Target=\"styles.xml\"/>");
relsContent = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" + XmlFuncs.XmlString("Relationships", new Dictionary<string, string> {{"xmlns", "http://schemas.openxmlformats.org/package/2006/relationships"}}, relSheets);

// Construct SharedStrings:
sharedContent = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>";
List<string> uniques = new List<string> ();
foreach(string unique in sharedStrs) {
    uniques.Add(XmlFuncs.XmlString("si", XmlFuncs.XmlString("t", unique)));
}
sharedContent += XmlFuncs.XmlString("sst", new Dictionary<string, string> {{"xmlns", xmlns}, {"count", count.ToString()}, {"uniqueCount", uniqueCount.ToString()}}, uniques);

// Edit [Content-Types]:
ZipArchiveEntry cTypes = archive.GetEntry("[Content_Types].xml")!;
string typesContent;
using (StreamReader sr = new StreamReader(cTypes.Open())) typesContent = sr.ReadToEnd();
List<string> typeNodes = typesContent.Split('>').ToList();
typesContent = typeNodes[0] + '>' + typeNodes[1] + '>' + typeNodes[2] + '>';
typesContent += XmlFuncs.XmlString("Override", new Dictionary<string, string> {{"PartName","/xl/worksheets/sheet" + (sheets.Count + 1) + ".xml"}, {"ContentType", "application/vnd.openxmlformats-officedocument.spreadsheetml.worksheet+xml"}});
for(int i = 3; i < typeNodes.Count; i++) {
    typesContent += typeNodes[i] + '>';
}

// Overwrite:
using (StreamWriter sw = new StreamWriter(workbook.Open()))
    foreach (char letter in workContent)
        sw.Write(letter);

using (StreamWriter sw = new StreamWriter(sheet.Open()))
    foreach (char letter in sheetData)
        sw.Write(letter);

using (StreamWriter sw = new StreamWriter(rels.Open()))
    foreach (char letter in relsContent)
        sw.Write(letter);

using (StreamWriter sw = new StreamWriter(sharedStrings.Open()))
    foreach (char letter in sharedContent)
        sw.Write(letter);

using (StreamWriter sw = new StreamWriter(cTypes.Open()))
    foreach (char letter in typesContent)
        sw.Write(letter);

archive.Dispose();
zipArchive.Dispose();
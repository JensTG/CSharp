using System.Data;
using System.Globalization;
using XmlTest;

List<char> alphabet = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
int cols = 3;
int rows = 10;
List<string> cells = new List<string>();
Dictionary<string, string> atts = new Dictionary<string, string> ();
string output = "";

for (int r = 1; r < rows + 1; r++)
{
    cells.Clear();
    for (int c = 0; c < cols; c++)
    {
        atts.Clear();
        string val = XmlNode.XmlString("v", (2 * c + 1).ToString());
        if (c < 2)
        {
            atts.Add("r", alphabet[c] + r.ToString());
            atts.Add("t", "s");
            cells.Add(XmlNode.XmlString("c", atts, val));
        }
        else
        {
            atts.Add("r", alphabet[c] + r.ToString());
            cells.Add(XmlNode.XmlString("c", atts, val));
        }
        
    }
    atts.Clear();
    atts.Add("r", r.ToString());
    atts.Add("spans", $"1:{cols}");
    atts.Add("x14ac:dyDescent", "0.25");
    output += XmlNode.XmlString("row", atts, cells);
}
Console.WriteLine(output);

// <row r="2" spans="1:3" x14ac:dyDescent="0.25">
//     <c r="A2" t="s">
//         <v>6</v>
//     </c>
//     <c r="B2" t="s">
//         <v>7</v>
//     </c>
//     <c r="C2">
//         <v>1</v>
//     </c>
// </row>
namespace XmlTest
{
    public static class XmlFuncs
    {
        public static string XmlString(string name, Dictionary<string, string> atts, string value)
        {
            string output = $"<{name} ";
            foreach (KeyValuePair<string, string> att in atts)
            {
                output += $"{att.Key}=\"{att.Value}\" ";
            }
            output.Remove(output.Count() - 1);
            output += $">{value}</{name}>";
            return output;
        }
        public static string XmlString(string name, Dictionary<string, string> atts)
        {
            string output = $"<{name} ";
            foreach (KeyValuePair<string, string> att in atts)
            {
                output += $"{att.Key}=\"{att.Value}\" ";
            }
            output.Remove(output.Count() - 1);
            output += $"/>";
            return output;
        }
        public static string XmlString(string name, string value)
        {
            string output = $"<{name}>{value}</{name}>";
            return output;
        }
        public static string XmlString(string name, List<string> vals)
        {
            string output = $"<{name}>";
            foreach (string val in vals)
            {
                output += val;
            }
            output += $"</{name}>";
            return output;
        }
        public static string XmlString(string name, Dictionary<string, string> atts, List<string> vals)
        {
            string output = $"<{name} ";
            foreach (KeyValuePair<string, string> att in atts)
            {
                output += $"{att.Key}=\"{att.Value}\" ";
            }
            output.Remove(output.Count() - 1);
            output += ">";
            foreach (string val in vals)
            {
                output += val;
            }
            output += $"</{name}>";
            return output;
        }
    }
}

// <row r="1" spans="1:3" x14ac:dyDescent="0.25">
//     <c r="A1" t="s">
//         <v>3</v>
//     </c>
//     <c r="B1" t="s">
//         <v>4</v>
//     </c>
//     <c r="C1" t="s">
//         <v>5</v>
//     </c>
// </row>

// <selection activeCell="A1" sqref="A1"/>}
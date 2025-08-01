#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        StringBuilder sb = new StringBuilder();
        string line = sr.ReadLine();
        string[] letter = sr.ReadLine().Split(' ');
        foreach (char c in line)
        {
            string s = c.ToString();
            if (letter.Contains(s))
            {
                sb.Append(s.ToLower());
            }
            else
            {
                sb.Append(s);
            }
        }
        sw.Write(sb);
    }
}

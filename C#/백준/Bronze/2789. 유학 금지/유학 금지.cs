#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string line = sr.ReadLine();
        string text = "CAMBRIDGE";
        StringBuilder sb = new StringBuilder();
        foreach (var item in line)
        {
            if(!text.Contains(item))
                sb.Append(item);
        }
        sw.Write(sb);
    }
}

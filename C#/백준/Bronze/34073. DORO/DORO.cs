#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        string[] strings = sr.ReadLine().Split();
        StringBuilder sb = new StringBuilder();
        foreach (var item in strings)
        {
            sb.Append($"{item}DORO ");
        }
        sw.Write(sb);
    }
}

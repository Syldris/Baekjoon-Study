#nullable disable
using System;
using System.Numerics;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string text = sr.ReadLine();
        string[] strings = new string[text.Length];
        for (int i = 0; i < text.Length; i++)
        {
            strings[i] = text[i..^0];
        }
        strings = strings.OrderBy(x => x).ToArray();
        foreach (var item in strings)
        {
            sw.WriteLine(item);
        }
    }
}

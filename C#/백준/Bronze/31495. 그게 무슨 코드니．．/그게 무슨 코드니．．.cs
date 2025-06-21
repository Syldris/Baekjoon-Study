#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string text = sr.ReadLine();
        if (text[0] == text[^1] && text[0] == '"' && text.Length > 2)
        {
            sw.Write(text[1..^1]);
        }
        else
        {
            sw.Write("CE");
        }
    }
}

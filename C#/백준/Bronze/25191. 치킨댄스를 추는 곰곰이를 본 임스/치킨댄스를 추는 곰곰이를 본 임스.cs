#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int a = int.Parse(sr.ReadLine());
        string[] line = sr.ReadLine().Split();
        int b = int.Parse(line[0]);
        int c = int.Parse(line[1]);
        int value = b / 2 + c;
        sw.Write(Math.Min(a, value));
    }
}

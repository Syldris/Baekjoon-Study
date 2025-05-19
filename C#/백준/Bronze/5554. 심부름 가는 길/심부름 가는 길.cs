using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int a = int.Parse(sr.ReadLine());
        int b = int.Parse(sr.ReadLine());
        int c = int.Parse(sr.ReadLine());
        int d = int.Parse(sr.ReadLine());
        sw.WriteLine((a + b + c + d) / 60);
        sw.WriteLine((a + b + c + d) % 60);
    }
}
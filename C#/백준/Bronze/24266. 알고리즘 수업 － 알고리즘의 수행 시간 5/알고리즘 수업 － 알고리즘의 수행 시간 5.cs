#nullable disable
using System;
using System.Net.Sockets;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        sw.WriteLine((long)n*n*n);
        sw.WriteLine(3);
    }
}

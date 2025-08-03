#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] line = sr.ReadLine().Split();
        int n = int.Parse(line[0]);
        int time = int.Parse(line[1]);
        int count = int.Parse(line[2]);
        int price = int.Parse(line[3]);

        sw.Write((n-1)/time * count * price);
    }
}

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
        long a = long.Parse(line[0]);
        long b = long.Parse(line[1]);

        if (a > b)
            (a, b) = (b, a);

        List<long> list = new List<long>();

        for (long i = a + 1; i < b; i++)
        {
            list.Add(i);
        }
        sw.WriteLine(a == b ? 0 : b - a - 1);
        sw.WriteLine(String.Join(" ", list));
    }
}

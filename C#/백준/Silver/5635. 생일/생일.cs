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
        (string name, int day, int month, int year)[] data = new (string, int, int, int)[n];

        for (int i = 0; i < n; i++)
        {
            string[] line = sr.ReadLine().Split();
            data[i] = (line[0], int.Parse(line[1]), int.Parse(line[2]), int.Parse(line[3]));
        }

        data = data.OrderBy(x => x.year).ThenBy(x => x.month).ThenBy(x => x.day).ToArray();
        sw.WriteLine(data[^1].name);
        sw.WriteLine(data[0].name);
    }
}

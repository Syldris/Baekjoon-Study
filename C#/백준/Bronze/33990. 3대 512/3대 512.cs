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
        int result = int.MaxValue;
        for (int i = 0; i < n; i++)
        {
            string[] line = sr.ReadLine().Split();
            int value = int.Parse(line[0]) + int.Parse(line[1]) + int.Parse(line[2]);
            if (value >= 512)
            {
                result = Math.Min(result, value);
            }
        }
        sw.Write(result == int.MaxValue ? -1 : result);
    }
}

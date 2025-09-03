#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int[] input = sr.ReadLine().Split().Select(int.Parse).ToArray();

        int[] line1 = sr.ReadLine().Split().Select(int.Parse).ToArray();
        int[] line2 = sr.ReadLine().Split().Select(int.Parse).ToArray();
        int[] line3 = sr.ReadLine().Split().Select(int.Parse).ToArray();

        int min = 0;
        int max = 0;
        min = Math.Min(Math.Min(line1[0], line2[0]), line3[0]);
        max = Math.Max(Math.Max(line1[1], line2[1]), line3[1]);
        int result = 0;
        for (int i = min; i <= max; i++)
        {
            int cur = 0;
            if (line1[0] <= i && i < line1[1])
                cur++;
            if (line2[0] <= i && i < line2[1])
                cur++;
            if (line3[0] <= i && i < line3[1])
                cur++;
            if(cur == 0)
                continue;
            result += input[cur - 1] * cur;
        }
        sw.Write(result);
    }
}

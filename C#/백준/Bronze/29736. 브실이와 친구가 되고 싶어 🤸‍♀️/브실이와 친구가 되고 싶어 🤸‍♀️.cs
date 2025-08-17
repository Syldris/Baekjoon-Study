#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int a = int.Parse(input[0]);
        int b = int.Parse(input[1]);

        string[] input2 = sr.ReadLine().Split();
        int x = int.Parse(input2[0]);
        int k = int.Parse(input2[1]);
        int result = 0;
        for (int i = a; i <= b; i++)
        {
            if (x - k <= i && i <= x + k)
            {
                result++;
            }
        }
        sw.WriteLine(result == 0 ? "IMPOSSIBLE" : result);
    }
}

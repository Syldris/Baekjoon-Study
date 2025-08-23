#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int[] line1 = sr.ReadLine().Split().Select(int.Parse).ToArray();
        int[] line2 = sr.ReadLine().Split().Select(int.Parse).ToArray();
        int value = 0;
        for (int i = 0; i < 3; i++)
        {
            if (line2[i] > line1[i])
            {
                value += line2[i] - line1[i];
            }
        }
        sw.WriteLine(value);
    }
}

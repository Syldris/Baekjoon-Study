#nullable disable
using System;
using System.Numerics;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        int min = 1, max = m;

        int k = int.Parse(sr.ReadLine());
        int result = 0;
        for (int i = 0; i < k; i++)
        {
            int value = int.Parse(sr.ReadLine());
            if (value > max)
            {
                int move = value - max;
                result += move;
                min += move;
                max += move;
            }
            else if(value < min)
            {
                int move = min - value;
                result += move;
                min -= move;
                max -= move;
            }
        }
        sw.WriteLine(result);
    }
}

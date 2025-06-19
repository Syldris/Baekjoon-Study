#nullable disable
using System.Numerics;

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int value = int.Parse(sr.ReadLine());
        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            int curValue = int.Parse(sr.ReadLine());
            int absValue = Math.Abs(curValue - value);
            sum += Math.Min(absValue, Math.Abs(absValue - 360));
            value = curValue;
        }
        sw.Write(sum);
    }
}
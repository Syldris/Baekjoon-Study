#nullable disable
using System.Diagnostics;

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 20);

        float value = float.Parse(sr.ReadLine());

        while (true)
        {
            float num = float.Parse(sr.ReadLine());
            if (num == 999f) break;

            sw.WriteLine($"{num - value:F2}");
            value = num;
        }
    }
}
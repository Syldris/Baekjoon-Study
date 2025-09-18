#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int max = 0;
        int index = 0;
        for (int i = 0; i < 5; i++)
        {
            int[] line = sr.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int value = 0;
            foreach (var item in line)
            {
                value += item;
            }
            if (value > max)
            {
                max = value;
                index = i + 1;
            }
        }
        sw.WriteLine($"{index} {max}");

    }
}

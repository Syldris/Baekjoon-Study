#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        while (true)
        {
            int[] line = sr.ReadLine().Split().Select(int.Parse).ToArray();
            int result = 1;
            if (line[0] == 0)
            {
                break;
            }
            for (int i = 1; i < line.Length; i+=2)
            {
                result *= line[i];
                result -= line[i+1];
            }
            sw.WriteLine(result);
        }
    }
}

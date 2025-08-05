#nullable disable
using System;
using System.Net.Sockets;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            int value = int.Parse(sr.ReadLine());
            string line = sr.ReadLine();
            foreach (var item in line)
            {
                if (item == 'b')
                    value--;
                else
                    value++;
            }
            sw.WriteLine($"Data Set {i}:");
            sw.WriteLine(value);
            sw.WriteLine();
        }
    }
}

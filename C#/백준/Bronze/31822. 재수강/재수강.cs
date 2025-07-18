#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string input = sr.ReadLine();
        int n = int.Parse(sr.ReadLine());
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            string line = sr.ReadLine();
            if (input[0..5] == line[0..5])
            {
                count++;
            }
        }
        sw.Write(count);
    }
}

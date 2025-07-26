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
            string line = sr.ReadLine();
            if(line == "END")
                break;

            StringBuilder sb = new StringBuilder();
            for (int i = line.Length - 1; i >= 0; i--)
            {
                sb.Append(line[i]);
            }
            sw.WriteLine(sb);
        }
    }
}

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
            if(line == "# 0 0")
                break;

            string[] input = line.Split();
            string name = input[0];
            int age = int.Parse(input[1]);
            int weight = int.Parse(input[2]);

            StringBuilder sb = new StringBuilder();
            sb.Append(name);
            if (age > 17 || weight >= 80)
            {
                sb.Append(" Senior");
            }
            else
            {
                sb.Append(" Junior");
            }
            sw.WriteLine(sb);
        }
    }
}

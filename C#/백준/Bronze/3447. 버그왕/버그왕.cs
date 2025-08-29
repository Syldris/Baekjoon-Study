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
            if(line == null)
                break;
            while (line.Contains("BUG"))
            {
                line = line.Replace("BUG", "");
            }
            sw.WriteLine(line);
        }
    }
}

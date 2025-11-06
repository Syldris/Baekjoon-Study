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
            if (line == null)
            {
                break;
            }
            string[] input = line.Split();
            string s = input[0];
            string t = input[1];

            int index = 0;

            foreach (var item in t)
            {
                if (index != s.Length && item == s[index])
                {
                    index++;
                }
            }

            sw.WriteLine(index == s.Length ? "Yes" : "No");
        }
    }
}
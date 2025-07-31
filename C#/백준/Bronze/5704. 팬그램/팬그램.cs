#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        while (true)
        {
            string line = sr.ReadLine();
            if (line == "*")
                break;
            bool[] bools = new bool[26];

            foreach (var item in line)
            {
                if(char.IsLetter(item))
                    bools[item - 'a'] = true;
            }

            sw.WriteLine(bools.All(x => x) ? "Y" : "N");

        }
    }
}

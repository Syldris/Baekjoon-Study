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
            string[] text = sr.ReadLine().Split();
            if (text[0] == "#")
            {
                break;
            }
            foreach (var item in text)
            {
                string line = new string(item.Reverse().ToArray());
                sw.Write(line);
                sw.Write(' ');
            }
            sw.WriteLine();
        }
    }
}
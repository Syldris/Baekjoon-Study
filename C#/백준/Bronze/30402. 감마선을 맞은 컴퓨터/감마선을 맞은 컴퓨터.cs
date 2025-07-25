#nullable disable
using System;
using System.Numerics;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        while (true)
        {
            string[] line = sr.ReadLine().Split();
            foreach (var item in line)
            {
                if (item == "w")
                {
                    sw.Write("chunbae");
                    return;
                }
                else if (item == "b")
                {
                    sw.Write("nabi");
                    return;
                }
                else if (item == "g")
                {
                    sw.Write("yeongcheol");
                    return;
                }
            }
        }
    }
}

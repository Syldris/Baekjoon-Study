#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int value = 0;
        for (int i = 0; i < n; i++)
        {
            string line = sr.ReadLine();
            int len = line.Length / 2;
            string text1 = line[0..len];
            string text2 = new string(line[len..line.Length].Reverse().ToArray());
            if (text1 == text2)
                value++;
        }

        sw.Write(value * (value-1));
    }
}

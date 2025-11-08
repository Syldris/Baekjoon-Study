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
            string n = sr.ReadLine();
            if (n == "0")
            {
                break;
            }
            int result = n.Length + 1;
            foreach (var item in n)
            {
                if (item == '1')
                {
                    result += 2;
                }
                else if (item == '0')
                {
                    result += 4;
                }
                else
                {
                    result += 3;
                }
            }
            sw.WriteLine(result);
        }
    }
}
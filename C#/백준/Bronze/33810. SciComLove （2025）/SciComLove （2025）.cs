#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        string name = "SciComLove";
        int count = 0;
        string input = sr.ReadLine();
        for (int i = 0; i < 10; i++)
        {
            if (name[i] != input[i])
            {
                count++;
            }
        }
        sw.Write(count);
    }
}

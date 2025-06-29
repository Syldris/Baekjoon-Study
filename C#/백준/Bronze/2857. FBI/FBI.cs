#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int count = 1;
        bool fbi = false;
        while (true)
        {
            string line = sr.ReadLine();
            if(line == null)
                break;
            if (line.Contains("FBI"))
            {
                sw.Write($"{count} ");
                fbi = true;
            }
            count++;
        }
        if(!fbi)
            sw.Write("HE GOT AWAY!");
    }
}

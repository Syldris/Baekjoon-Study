#nullable disable
using System;
using System.Linq;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        int a = int.Parse(sr.ReadLine());
        int b = int.Parse(sr.ReadLine());
        int c = int.Parse(sr.ReadLine());
        int d = int.Parse(sr.ReadLine());
        int e = int.Parse(sr.ReadLine());
        int time = 0;
        bool thaw = false;
        while (a != b)
        {
            if (a == 0 && !thaw)
            {
                time += d;
                thaw = true;
            }
            else if(a >= 0)
            {
                time += e;
                a++;
            }
            else
            {
                time += c;
                a++;
            }
        }
        sw.WriteLine(time);
    }
}

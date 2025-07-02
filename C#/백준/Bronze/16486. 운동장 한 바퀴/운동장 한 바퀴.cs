#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        
        int D1 = int.Parse(sr.ReadLine());
        int D2 = int.Parse(sr.ReadLine());

        double value = D1 * 2 + D2 * 2 * 3.141592;

        sw.Write("{0:F6}", value);
    }
}

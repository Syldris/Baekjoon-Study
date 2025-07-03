#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        for (int i = 0; i < n; i++)
        {
            int value = int.Parse(sr.ReadLine());
            if ((value + 1) % (value % 100) == 0)
            {
                sw.WriteLine("Good");
            }
            else
            {
                sw.WriteLine("Bye"); 
            }
        }
    }
}

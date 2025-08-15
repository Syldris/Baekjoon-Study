#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] line = sr.ReadLine().Split();
        int n = int.Parse(line[0]);
        int k = int.Parse(line[1]);
        if (n == 1)
        {
            for (int i = 1; i <= k; i++)
                sw.Write("1 ");
        }
        else if(n == 2 && k == 1)
        {
            sw.Write("1 2");
        }
        else
        {
            sw.Write(-1);
        }
    }
}

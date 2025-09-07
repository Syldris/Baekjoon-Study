#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split(' ');
        int e = int.Parse(input[0]);
        int s = int.Parse(input[1]);
        int m = int.Parse(input[2]);

        int result = 0;
        int earth = 0;
        int sun = 0; 
        int moon = 0;

        while (true)
        {

            if (e == earth && s == sun && m == moon)
            {
                break;
            }
            earth++;
            sun++;
            moon++;
            result++;
            if (earth > 15)
                earth = 1;
            if (sun > 28)
                sun = 1;
            if(moon > 19)
                moon = 1;
        }

        sw.Write(result);
    }
}

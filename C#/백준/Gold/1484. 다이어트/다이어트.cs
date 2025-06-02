#nullable disable
using System.Numerics;

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        bool hasAnswer = false;

        int start = 1, end = 2;
        while (end <= 100000)
        {
            int value = end * end - start * start;
            if(value == n)
            {
                sw.WriteLine(end);
                end++;
                hasAnswer = true;
            }
            else if(value < n)
            {
                end++;
            }
            else
            {
                start++;
            }
        }
        if(!hasAnswer)
            sw.WriteLine(-1);
    }
}